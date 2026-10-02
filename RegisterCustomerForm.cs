using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargillsPayPoint_WinForms;

public class RegisterCustomerForm : Form
{
    private static readonly Color PrimaryRed = ColorTranslator.FromHtml("#BE1A1A");
    private static readonly Color AccentRed = ColorTranslator.FromHtml("#D0311E");
    private static readonly Color GoldWarm = ColorTranslator.FromHtml("#F7D87F");
    private static readonly Color GoldCream = ColorTranslator.FromHtml("#F8EBAB");

    private readonly HttpClient _http = new() { Timeout = TimeSpan.FromSeconds(10) };

    private TextBox txtName = null!;
    private TextBox txtAccount = null!;
    private TextBox txtAddress = null!;
    private NumericUpDown numAmount = null!;
    private DateTimePicker dtpDueDate = null!;
    private Button btnAutoAcc = null!;
    private Button btnSubmit = null!;
    private Button btnCancel = null!;
    private Label lblMsg = null!;

    public string? CreatedAccountNumber { get; private set; }
    public int? CreatedBillId { get; private set; }
    public decimal? CreatedBillAmount { get; private set; }

    public RegisterCustomerForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Register New Water Board Consumer — Cargills PayPoint";
        this.Size = new Size(520, 500);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.FromArgb(250, 250, 250);

        // Header Panel
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = PrimaryRed
        };

        var lblHeaderTitle = new Label
        {
            Text = "➕ REGISTER NEW WATER BOARD CONSUMER",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            Location = new Point(15, 12),
            AutoSize = true
        };

        var lblHeaderSub = new Label
        {
            Text = "NWSDB Customer Registration & Opening Bill Issuance Gateway",
            ForeColor = GoldCream,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(17, 36),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblHeaderTitle);
        pnlHeader.Controls.Add(lblHeaderSub);
        this.Controls.Add(pnlHeader);

        // Form Fields
        int startY = 80;
        int rowH = 50;

        // 1. Customer Name
        var lblName = new Label
        {
            Text = "Full Customer Name *",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Location = new Point(25, startY),
            Size = new Size(200, 18)
        };
        txtName = new TextBox
        {
            Location = new Point(25, startY + 20),
            Size = new Size(450, 27),
            Font = new Font("Segoe UI", 10F),
            PlaceholderText = "e.g. Priyantha Bandara"
        };
        this.Controls.Add(lblName);
        this.Controls.Add(txtName);

        // 2. Account Number
        startY += rowH + 5;
        var lblAcc = new Label
        {
            Text = "Utility Account Number (Auto-Suggested or Custom) *",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Location = new Point(25, startY),
            Size = new Size(350, 18)
        };
        txtAccount = new TextBox
        {
            Location = new Point(25, startY + 20),
            Size = new Size(310, 27),
            Font = new Font("Consolas", 10F, FontStyle.Bold),
            Text = "WTR-" + Random.Shared.Next(100000, 999999).ToString()
        };
        btnAutoAcc = new Button
        {
            Location = new Point(345, startY + 19),
            Size = new Size(130, 29),
            Text = "🎲 Regenerate",
            BackColor = GoldWarm,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
        };
        btnAutoAcc.Click += (s, e) =>
        {
            txtAccount.Text = "WTR-" + Random.Shared.Next(100000, 999999).ToString();
        };
        this.Controls.Add(lblAcc);
        this.Controls.Add(txtAccount);
        this.Controls.Add(btnAutoAcc);

        // 3. Address
        startY += rowH + 5;
        var lblAddr = new Label
        {
            Text = "Premises / Billing Address *",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Location = new Point(25, startY),
            Size = new Size(200, 18)
        };
        txtAddress = new TextBox
        {
            Location = new Point(25, startY + 20),
            Size = new Size(450, 27),
            Font = new Font("Segoe UI", 10F),
            PlaceholderText = "e.g. No 72/A, Kandy Road, Kadawatha"
        };
        this.Controls.Add(lblAddr);
        this.Controls.Add(txtAddress);

        // 4. Initial Bill & Due Date
        startY += rowH + 5;
        var lblAmount = new Label
        {
            Text = "Opening Bill (LKR)",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Location = new Point(25, startY),
            Size = new Size(150, 18)
        };
        numAmount = new NumericUpDown
        {
            Location = new Point(25, startY + 20),
            Size = new Size(200, 27),
            Font = new Font("Consolas", 10F, FontStyle.Bold),
            Minimum = 0,
            Maximum = 500000,
            DecimalPlaces = 2,
            Value = 1850.00m
        };

        var lblDue = new Label
        {
            Text = "Payment Due Date",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Location = new Point(250, startY),
            Size = new Size(150, 18)
        };
        dtpDueDate = new DateTimePicker
        {
            Location = new Point(250, startY + 20),
            Size = new Size(225, 27),
            Font = new Font("Segoe UI", 9.5F),
            Value = DateTime.Today.AddDays(30)
        };
        this.Controls.Add(lblAmount);
        this.Controls.Add(numAmount);
        this.Controls.Add(lblDue);
        this.Controls.Add(dtpDueDate);

        // Status / error label
        startY += rowH + 10;
        lblMsg = new Label
        {
            Location = new Point(25, startY),
            Size = new Size(450, 20),
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = AccentRed,
            Text = ""
        };
        this.Controls.Add(lblMsg);

        // Buttons
        startY += 28;
        btnSubmit = new Button
        {
            Location = new Point(25, startY),
            Size = new Size(280, 42),
            Text = "✔ Register & Open Bill",
            BackColor = AccentRed,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSubmit.Click += async (s, e) => await SubmitRegistrationAsync();

        btnCancel = new Button
        {
            Location = new Point(315, startY),
            Size = new Size(160, 42),
            Text = "Cancel",
            BackColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F),
            DialogResult = DialogResult.Cancel
        };
        this.Controls.Add(btnSubmit);
        this.Controls.Add(btnCancel);
    }

    private async Task SubmitRegistrationAsync()
    {
        var name = txtName.Text.Trim();
        var acc = txtAccount.Text.Trim().ToUpper();
        var addr = txtAddress.Text.Trim();
        var amount = numAmount.Value;
        var due = dtpDueDate.Value;

        if (string.IsNullOrWhiteSpace(name))
        {
            lblMsg.Text = "Please enter consumer full name.";
            txtName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(acc))
        {
            lblMsg.Text = "Please enter utility account number.";
            txtAccount.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(addr))
        {
            lblMsg.Text = "Please enter consumer address.";
            txtAddress.Focus();
            return;
        }

        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;
        lblMsg.ForeColor = Color.FromArgb(30, 64, 175);
        lblMsg.Text = "Communicating with NWSDB Core Gateway (:5123)...";

        try
        {
            var reqObj = new
            {
                customerName = name,
                accountNumber = acc,
                customerAddress = addr,
                initialBillAmount = amount,
                dueDate = due.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };

            var res = await _http.PostAsJsonAsync("http://localhost:5123/api/customer", reqObj);
            var json = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                CreatedAccountNumber = acc;
                if (root.TryGetProperty("initialBill", out var billProp) && billProp.ValueKind == JsonValueKind.Object)
                {
                    if (billProp.TryGetProperty("billId", out var billIdVal))
                    {
                        CreatedBillId = billIdVal.GetInt32();
                    }
                    if (billProp.TryGetProperty("amount", out var amtVal))
                    {
                        CreatedBillAmount = amtVal.GetDecimal();
                    }
                }

                MessageBox.Show(
                    $"Consumer '{name}' ({acc}) was registered successfully with NWSDB!\n\nOpening Bill ID: #{CreatedBillId}\nAmount Due: LKR {CreatedBillAmount:N2}\n\nLoading bill into cashier counter now...",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMsg.ForeColor = AccentRed;
                lblMsg.Text = $"Registration failed: HTTP {(int)res.StatusCode} - {json}";
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblMsg.ForeColor = AccentRed;
            lblMsg.Text = $"Network Error: {ex.Message}";
            btnSubmit.Enabled = true;
            btnCancel.Enabled = true;
        }
    }
}
