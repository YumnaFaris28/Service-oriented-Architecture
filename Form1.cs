using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargillsPayPoint_WinForms;

public partial class Form1 : Form
{
    private const string NwsdbApiBase = "http://localhost:5123/";
    private const string BankApiBase = "http://localhost:7123/";

    private static readonly Color PrimaryRed = ColorTranslator.FromHtml("#BE1A1A");
    private static readonly Color AccentRed = ColorTranslator.FromHtml("#D0311E");
    private static readonly Color GoldWarm = ColorTranslator.FromHtml("#F7D87F");
    private static readonly Color GoldCream = ColorTranslator.FromHtml("#F8EBAB");

    private readonly HttpClient _http = new() { Timeout = TimeSpan.FromSeconds(10) };
    private CurrentBill? _currentBill = null;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object? sender, EventArgs e)
    {
        await CheckConnectivityAsync();
        // Automatically perform initial lookup for Bill 101
        await LookupBillAsync("101");
    }

    private async void BtnCheckStatus_Click(object? sender, EventArgs e)
    {
        await CheckConnectivityAsync();
    }

    private async Task CheckConnectivityAsync()
    {
        lblStatusNwsdb.Text = "🌊 NWSDB Core (:5123): Pinging...";
        lblStatusNwsdb.ForeColor = Color.DarkGoldenrod;
        lblStatusBank.Text = "🏦 Bank Gateway (:7123): Pinging...";
        lblStatusBank.ForeColor = Color.DarkGoldenrod;

        bool nwsdbOk = false;
        long nwsdbMs = 0;
        try
        {
            var sw = Stopwatch.StartNew();
            var res = await _http.GetAsync($"{NwsdbApiBase}api/waterbill/all");
            sw.Stop();
            nwsdbMs = sw.ElapsedMilliseconds;
            nwsdbOk = res.IsSuccessStatusCode;
        }
        catch { nwsdbOk = false; }

        bool bankOk = false;
        long bankMs = 0;
        try
        {
            var sw = Stopwatch.StartNew();
            var res = await _http.GetAsync($"{BankApiBase}api/bank/status");
            sw.Stop();
            bankMs = sw.ElapsedMilliseconds;
            bankOk = res.IsSuccessStatusCode;
        }
        catch { bankOk = false; }

        if (nwsdbOk)
        {
            lblStatusNwsdb.Text = $"🌊 NWSDB Core (:5123): Connected ({nwsdbMs}ms) ✔";
            lblStatusNwsdb.ForeColor = Color.FromArgb(22, 101, 52);
        }
        else
        {
            lblStatusNwsdb.Text = "🌊 NWSDB Core (:5123): Offline ✖";
            lblStatusNwsdb.ForeColor = PrimaryRed;
        }

        if (bankOk)
        {
            lblStatusBank.Text = $"🏦 Bank Gateway (:7123): Connected ({bankMs}ms) ✔";
            lblStatusBank.ForeColor = Color.FromArgb(22, 101, 52);
        }
        else
        {
            lblStatusBank.Text = "🏦 Bank Gateway (:7123): Offline ✖";
            lblStatusBank.ForeColor = PrimaryRed;
        }
    }

    private async void BtnRegisterCustomer_Click(object? sender, EventArgs e)
    {
        using var reg = new RegisterCustomerForm();
        if (reg.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(reg.CreatedAccountNumber))
        {
            txtSearch.Text = reg.CreatedAccountNumber;
            await LookupBillAsync(reg.CreatedAccountNumber);
        }
    }

    private async void BtnSearch_Click(object? sender, EventArgs e)
    {
        var q = txtSearch.Text.Trim();
        if (string.IsNullOrWhiteSpace(q))
        {
            MessageBox.Show("Please enter an Account Number or Bill ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        await LookupBillAsync(q);
    }

    private async Task LookupBillAsync(string query)
    {
        btnSearch.Enabled = false;
        btnSearch.Text = "Searching...";

        try
        {
            CurrentBill? foundBill = null;

            // 1. If numeric, attempt to fetch by direct Bill ID first
            if (int.TryParse(query, out int billId))
            {
                var billRes = await _http.GetAsync($"{NwsdbApiBase}api/waterbill/{billId}");
                if (billRes.IsSuccessStatusCode)
                {
                    var json = await billRes.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    foundBill = new CurrentBill
                    {
                        BillId = root.GetProperty("billId").GetInt32(),
                        AccountNumber = root.GetProperty("accountNumber").GetString(),
                        Amount = root.GetProperty("amount").GetDecimal(),
                        DueDate = root.GetProperty("dueDate").GetDateTime(),
                        Status = root.GetProperty("status").GetString() ?? "Pending"
                    };

                    // Try to augment with customer name
                    if (!string.IsNullOrEmpty(foundBill.AccountNumber))
                    {
                        try
                        {
                            var custRes = await _http.GetAsync($"{NwsdbApiBase}api/customer/{foundBill.AccountNumber}");
                            if (custRes.IsSuccessStatusCode)
                            {
                                var custJson = await custRes.Content.ReadAsStringAsync();
                                using var custDoc = JsonDocument.Parse(custJson);
                                if (custDoc.RootElement.TryGetProperty("customer", out var cObj))
                                {
                                    foundBill.CustomerName = cObj.GetProperty("customerName").GetString();
                                    foundBill.CustomerAddress = cObj.GetProperty("customerAddress").GetString();
                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            // 2. If not found yet, search by Account Number
            if (foundBill == null)
            {
                var accRes = await _http.GetAsync($"{NwsdbApiBase}api/waterbill/account/{query}");
                if (accRes.IsSuccessStatusCode)
                {
                    var json = await accRes.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;
                    if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
                    {
                        // Get latest bill
                        var latest = root[root.GetArrayLength() - 1];
                        foundBill = new CurrentBill
                        {
                            BillId = latest.GetProperty("billId").GetInt32(),
                            AccountNumber = latest.GetProperty("accountNumber").GetString(),
                            Amount = latest.GetProperty("amount").GetDecimal(),
                            DueDate = latest.GetProperty("dueDate").GetDateTime(),
                            Status = latest.GetProperty("status").GetString() ?? "Pending"
                        };

                        try
                        {
                            var custRes = await _http.GetAsync($"{NwsdbApiBase}api/customer/{query}");
                            if (custRes.IsSuccessStatusCode)
                            {
                                var custJson = await custRes.Content.ReadAsStringAsync();
                                using var custDoc = JsonDocument.Parse(custJson);
                                if (custDoc.RootElement.TryGetProperty("customer", out var cObj))
                                {
                                    foundBill.CustomerName = cObj.GetProperty("customerName").GetString();
                                    foundBill.CustomerAddress = cObj.GetProperty("customerAddress").GetString();
                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            // 3. Update the UI accordingly
            if (foundBill != null)
            {
                _currentBill = foundBill;
                lblCustName.Text = _currentBill.CustomerName ?? "Registered Consumer";
                lblAccount.Text = _currentBill.AccountNumber ?? "N/A";
                lblAddress.Text = _currentBill.CustomerAddress ?? "NWSDB Billing Area";
                lblAmount.Text = $"LKR {_currentBill.Amount:N2}";
                lblDueDate.Text = _currentBill.DueDate.ToString("yyyy-MM-dd");
                lblBillStatus.Text = _currentBill.Status;

                bool isPaid = string.Equals(_currentBill.Status, "Paid", StringComparison.OrdinalIgnoreCase);
                lblBillStatus.ForeColor = isPaid ? Color.FromArgb(22, 101, 52) : AccentRed;

                txtTendered.Text = _currentBill.Amount.ToString("F2");
                UpdateChangeCalculation();

                if (isPaid)
                {
                    btnSettle.Enabled = false;
                    btnSettle.Text = "✔ ALREADY SETTLED (PAID)";
                    btnSettle.BackColor = Color.Gray;
                }
                else
                {
                    btnSettle.Enabled = true;
                    btnSettle.Text = "✔ COLLECT & SETTLE BILL VIA NWSDB API";
                    btnSettle.BackColor = AccentRed;
                }
            }
            else
            {
                MessageBox.Show($"No active water bills found matching '{query}'.\nTip: You can click '➕ Register New Consumer' to register this consumer and issue an opening bill.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Search failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSearch.Enabled = true;
            btnSearch.Text = "🔍 Find Bill";
        }
    }

    private void PaymentMethod_Changed(object? sender, EventArgs e)
    {
        if (rbCash.Checked)
        {
            lblTendered.Visible = true;
            txtTendered.Visible = true;
            lblChange.Visible = true;
            lblChangeAmount.Visible = true;
            UpdateChangeCalculation();
        }
        else
        {
            lblTendered.Visible = false;
            txtTendered.Visible = false;
            lblChange.Visible = false;
            lblChangeAmount.Visible = false;
        }
    }

    private void TxtTendered_TextChanged(object? sender, EventArgs e)
    {
        UpdateChangeCalculation();
    }

    private void UpdateChangeCalculation()
    {
        if (_currentBill == null)
        {
            lblChangeAmount.Text = "LKR 0.00";
            return;
        }

        if (decimal.TryParse(txtTendered.Text, out decimal tendered))
        {
            decimal change = tendered - _currentBill.Amount;
            if (change >= 0)
            {
                lblChangeAmount.Text = $"LKR {change:N2}";
                lblChangeAmount.ForeColor = Color.FromArgb(22, 101, 52);
            }
            else
            {
                lblChangeAmount.Text = $"Short: LKR {Math.Abs(change):N2}";
                lblChangeAmount.ForeColor = PrimaryRed;
            }
        }
        else
        {
            lblChangeAmount.Text = "Invalid Amount";
            lblChangeAmount.ForeColor = PrimaryRed;
        }
    }

    private async void BtnSettle_Click(object? sender, EventArgs e)
    {
        if (_currentBill == null)
        {
            MessageBox.Show("Please search and select an active utility bill first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.Equals(_currentBill.Status, "Paid", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("This bill is already settled.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        decimal tendered = _currentBill.Amount;
        if (rbCash.Checked)
        {
            if (!decimal.TryParse(txtTendered.Text, out tendered) || tendered < _currentBill.Amount)
            {
                MessageBox.Show($"Tendered cash must be at least LKR {_currentBill.Amount:N2}.", "Insufficient Tender", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        btnSettle.Enabled = false;
        btnSettle.Text = "⏳ Processing Payment with NWSDB Core & Bank API...";

        try
        {
            var paymentPayload = new
            {
                billId = _currentBill.BillId,
                accountNumber = _currentBill.AccountNumber,
                amount = _currentBill.Amount,
                cardNumber = rbCard.Checked ? "4532-CARGILLS-POS" : "CASH-PAYPOINT-TENDER",
                paymentToken = $"tok_winforms_pos_{DateTime.UtcNow.Ticks}",
                currency = "LKR",
                vendorName = "Cargills Food City (PayPoint #04)",
                cashierId = txtCashier.Text.Trim()
            };

            var response = await _http.PostAsJsonAsync($"{NwsdbApiBase}api/payment/process-payment", paymentPayload);
            var result = await response.Content.ReadFromJsonAsync<PaymentReceiptResult>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (response.IsSuccessStatusCode && result != null && result.IsSuccess)
            {
                // Succeeded! Generate Thermal Receipt
                decimal changeDue = tendered - _currentBill.Amount;
                var receiptText = GenerateThermalReceiptText(_currentBill, result, tendered, changeDue, rbCash.Checked ? "CASH" : "CARGILLS CARD / CARD POS");

                rtbReceipt.Text = receiptText;

                // Update UI status
                _currentBill.Status = "Paid";
                lblBillStatus.Text = "Paid";
                lblBillStatus.ForeColor = Color.FromArgb(22, 101, 52);
                btnSettle.Text = "✔ SETTLED SUCCESSFULLY!";
                btnSettle.BackColor = Color.Gray;

                MessageBox.Show($"Payment Authorized & Settled!\nBank Reference: {result.BankReference}\nReceipt generated on right panel.", "Payment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Settlement declined: {result?.Message ?? response.ReasonPhrase}", "Payment Declined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSettle.Enabled = true;
                btnSettle.Text = "✔ COLLECT & SETTLE BILL VIA NWSDB API";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing payment: {ex.Message}", "Network Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnSettle.Enabled = true;
            btnSettle.Text = "✔ COLLECT & SETTLE BILL VIA NWSDB API";
        }
    }

    private string GenerateThermalReceiptText(CurrentBill bill, PaymentReceiptResult result, decimal tendered, decimal change, string payMethod)
    {
        var receiptId = "CRG-POS-" + Guid.NewGuid().ToString()[..8].ToUpper();
        var now = DateTime.Now;

        return $@"================================================
           CARGILLS FOOD CITY (PVT) LTD
      UTILITY BILL PAYPOINT & RETAIL COUNTER
================================================
Store #104 - Staple Street, Colombo 02
Terminal : TERM-04   Cashier: {txtCashier.Text.Trim()}
Date/Time: {now:yyyy-MM-dd HH:mm:ss}
Receipt #: {receiptId}
------------------------------------------------
UTILITY SERVICE : NWSDB (Water Supply Board)
CONSUMER NAME   : {bill.CustomerName}
ACCOUNT NUMBER  : {bill.AccountNumber}
BILL INVOICE ID : #{bill.BillId}
SERVICE PERIOD  : Due by {bill.DueDate:yyyy-MM-dd}
------------------------------------------------
TOTAL AMOUNT DUE: LKR {bill.Amount,10:N2}
PAYMENT METHOD  : {payMethod}
AMOUNT TENDERED : LKR {tendered,10:N2}
CHANGE RETURNED : LKR {change,10:N2}
------------------------------------------------
BANK AUTHORIZATION & SETTLEMENT AUDIT:
GATEWAY SERVICE : External Commercial Bank Gateway
BANK REFERENCE  : {result.BankReference}
STATUS          : AUTHORIZED & SETTLED (PAID)
NWSDB RECORD ID : #{result.PaymentId}
------------------------------------------------
   ||| | ||||| || |||||||| ||||| |||| | |||||
              *NWSDB{bill.BillId}LKR{bill.Amount:F0}*

  Official Payment Receipt recognized by NWSDB.
   THANK YOU FOR SHOPPING AT CARGILLS FOOD CITY!
================================================
";
    }

    private class CurrentBill
    {
        public int BillId { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
    }

    private class PaymentReceiptResult
    {
        public int PaymentId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string BankReference { get; set; } = string.Empty;
        public DateTime ProcessedAt { get; set; }
        public int BillId { get; set; }
        public decimal AmountPaid { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
