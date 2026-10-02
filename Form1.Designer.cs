namespace CargillsPayPoint_WinForms;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        // Palette definitions
        var primaryRed = System.Drawing.ColorTranslator.FromHtml("#BE1A1A");
        var accentRed = System.Drawing.ColorTranslator.FromHtml("#D0311E");
        var goldWarm = System.Drawing.ColorTranslator.FromHtml("#F7D87F");
        var goldCream = System.Drawing.ColorTranslator.FromHtml("#F8EBAB");

        // Controls declaration
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.lblHeaderTitle = new System.Windows.Forms.Label();
        this.lblHeaderSubtitle = new System.Windows.Forms.Label();
        this.lblBrandBadge = new System.Windows.Forms.Label();

        this.pnlStatus = new System.Windows.Forms.Panel();
        this.lblStatusNwsdb = new System.Windows.Forms.Label();
        this.lblStatusBank = new System.Windows.Forms.Label();
        this.btnCheckStatus = new System.Windows.Forms.Button();

        this.grpLookup = new System.Windows.Forms.GroupBox();
        this.lblSearch = new System.Windows.Forms.Label();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.btnSearch = new System.Windows.Forms.Button();
        this.btnRegisterCustomer = new System.Windows.Forms.Button();
        this.btnQuick101 = new System.Windows.Forms.Button();
        this.btnQuick102 = new System.Windows.Forms.Button();
        this.btnQuick103 = new System.Windows.Forms.Button();

        this.grpBillInfo = new System.Windows.Forms.GroupBox();
        this.lblCustNameTitle = new System.Windows.Forms.Label();
        this.lblCustName = new System.Windows.Forms.Label();
        this.lblAccountTitle = new System.Windows.Forms.Label();
        this.lblAccount = new System.Windows.Forms.Label();
        this.lblAddressTitle = new System.Windows.Forms.Label();
        this.lblAddress = new System.Windows.Forms.Label();
        this.lblAmountTitle = new System.Windows.Forms.Label();
        this.lblAmount = new System.Windows.Forms.Label();
        this.lblDueDateTitle = new System.Windows.Forms.Label();
        this.lblDueDate = new System.Windows.Forms.Label();
        this.lblBillStatusTitle = new System.Windows.Forms.Label();
        this.lblBillStatus = new System.Windows.Forms.Label();

        this.grpPayment = new System.Windows.Forms.GroupBox();
        this.rbCash = new System.Windows.Forms.RadioButton();
        this.rbCard = new System.Windows.Forms.RadioButton();
        this.lblTendered = new System.Windows.Forms.Label();
        this.txtTendered = new System.Windows.Forms.TextBox();
        this.lblChange = new System.Windows.Forms.Label();
        this.lblChangeAmount = new System.Windows.Forms.Label();
        this.lblCashier = new System.Windows.Forms.Label();
        this.txtCashier = new System.Windows.Forms.TextBox();
        this.btnSettle = new System.Windows.Forms.Button();

        this.grpReceipt = new System.Windows.Forms.GroupBox();
        this.rtbReceipt = new System.Windows.Forms.RichTextBox();
        this.btnClearReceipt = new System.Windows.Forms.Button();

        this.pnlHeader.SuspendLayout();
        this.pnlStatus.SuspendLayout();
        this.grpLookup.SuspendLayout();
        this.grpBillInfo.SuspendLayout();
        this.grpPayment.SuspendLayout();
        this.grpReceipt.SuspendLayout();
        this.SuspendLayout();

        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = primaryRed; // #BE1A1A
        this.pnlHeader.Controls.Add(this.lblBrandBadge);
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new System.Drawing.Size(984, 75);
        this.pnlHeader.TabIndex = 0;

        // 
        // lblBrandBadge
        // 
        this.lblBrandBadge.AutoSize = true;
        this.lblBrandBadge.BackColor = goldWarm; // #F7D87F
        this.lblBrandBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblBrandBadge.ForeColor = primaryRed; // #BE1A1A
        this.lblBrandBadge.Location = new System.Drawing.Point(20, 14);
        this.lblBrandBadge.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
        this.lblBrandBadge.Text = "CARGILLS PAYPOINT";

        // 
        // lblHeaderTitle
        // 
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
        this.lblHeaderTitle.Location = new System.Drawing.Point(170, 10);
        this.lblHeaderTitle.Text = "CARGILLS FOOD CITY — UTILITY BILL PAYPOINT";

        // 
        // lblHeaderSubtitle
        // 
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblHeaderSubtitle.ForeColor = goldCream; // #F8EBAB
        this.lblHeaderSubtitle.Location = new System.Drawing.Point(172, 42);
        this.lblHeaderSubtitle.Text = "Store #104 (Staple St, Colombo 02) • Terminal #04 • Decoupled NWSDB Water Board SOA Client";

        // 
        // pnlStatus
        // 
        this.pnlStatus.BackColor = goldCream; // #F8EBAB
        this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlStatus.Controls.Add(this.btnCheckStatus);
        this.pnlStatus.Controls.Add(this.lblStatusBank);
        this.pnlStatus.Controls.Add(this.lblStatusNwsdb);
        this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlStatus.Location = new System.Drawing.Point(0, 75);
        this.pnlStatus.Name = "pnlStatus";
        this.pnlStatus.Size = new System.Drawing.Size(984, 38);
        this.pnlStatus.TabIndex = 1;

        // 
        // lblStatusNwsdb
        // 
        this.lblStatusNwsdb.AutoSize = true;
        this.lblStatusNwsdb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblStatusNwsdb.ForeColor = primaryRed;
        this.lblStatusNwsdb.Location = new System.Drawing.Point(20, 10);
        this.lblStatusNwsdb.Text = "🌊 NWSDB Core Gateway (:5123): Checking...";

        // 
        // lblStatusBank
        // 
        this.lblStatusBank.AutoSize = true;
        this.lblStatusBank.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblStatusBank.ForeColor = primaryRed;
        this.lblStatusBank.Location = new System.Drawing.Point(380, 10);
        this.lblStatusBank.Text = "🏦 Bank Gateway (:7123): Checking...";

        // 
        // btnCheckStatus
        // 
        this.btnCheckStatus.BackColor = primaryRed;
        this.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCheckStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.btnCheckStatus.ForeColor = System.Drawing.Color.White;
        this.btnCheckStatus.Location = new System.Drawing.Point(780, 5);
        this.btnCheckStatus.Size = new System.Drawing.Size(180, 26);
        this.btnCheckStatus.Text = "🔄 Refresh Connectivity";
        this.btnCheckStatus.UseVisualStyleBackColor = false;
        this.btnCheckStatus.Click += new System.EventHandler(this.BtnCheckStatus_Click);

        // 
        // grpLookup
        // 
        this.grpLookup.Controls.Add(this.btnRegisterCustomer);
        this.grpLookup.Controls.Add(this.btnQuick103);
        this.grpLookup.Controls.Add(this.btnQuick102);
        this.grpLookup.Controls.Add(this.btnQuick101);
        this.grpLookup.Controls.Add(this.btnSearch);
        this.grpLookup.Controls.Add(this.txtSearch);
        this.grpLookup.Controls.Add(this.lblSearch);
        this.grpLookup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpLookup.Location = new System.Drawing.Point(20, 122);
        this.grpLookup.Name = "grpLookup";
        this.grpLookup.Size = new System.Drawing.Size(520, 135);
        this.grpLookup.TabIndex = 2;
        this.grpLookup.TabStop = false;
        this.grpLookup.Text = "1. Customer Bill Lookup & Registration";

        // 
        // lblSearch
        // 
        this.lblSearch.AutoSize = true;
        this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSearch.Location = new System.Drawing.Point(15, 25);
        this.lblSearch.Text = "Enter Account # or Bill ID:";

        // 
        // txtSearch
        // 
        this.txtSearch.Font = new System.Drawing.Font("Consolas", 10.5F);
        this.txtSearch.Location = new System.Drawing.Point(18, 46);
        this.txtSearch.Size = new System.Drawing.Size(240, 28);
        this.txtSearch.Text = "101";

        // 
        // btnSearch
        // 
        this.btnSearch.BackColor = accentRed; // #D0311E
        this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSearch.ForeColor = System.Drawing.Color.White;
        this.btnSearch.Location = new System.Drawing.Point(265, 45);
        this.btnSearch.Size = new System.Drawing.Size(95, 30);
        this.btnSearch.Text = "🔍 Find Bill";
        this.btnSearch.UseVisualStyleBackColor = false;
        this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

        // 
        // btnRegisterCustomer
        // 
        this.btnRegisterCustomer.BackColor = primaryRed; // #BE1A1A
        this.btnRegisterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRegisterCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnRegisterCustomer.ForeColor = System.Drawing.Color.White;
        this.btnRegisterCustomer.Location = new System.Drawing.Point(18, 86);
        this.btnRegisterCustomer.Size = new System.Drawing.Size(342, 34);
        this.btnRegisterCustomer.Text = "➕ Register New Consumer & Issue Bill";
        this.btnRegisterCustomer.UseVisualStyleBackColor = false;
        this.btnRegisterCustomer.Click += new System.EventHandler(this.BtnRegisterCustomer_Click);

        // 
        // btnQuick101
        // 
        this.btnQuick101.BackColor = goldCream;
        this.btnQuick101.Font = new System.Drawing.Font("Segoe UI", 8F);
        this.btnQuick101.Location = new System.Drawing.Point(375, 23);
        this.btnQuick101.Size = new System.Drawing.Size(130, 25);
        this.btnQuick101.Text = "Sample #101";
        this.btnQuick101.UseVisualStyleBackColor = false;
        

        // 
        // btnQuick102
        // 
        this.btnQuick102.BackColor = goldCream;
        this.btnQuick102.Font = new System.Drawing.Font("Segoe UI", 8F);
        this.btnQuick102.Location = new System.Drawing.Point(375, 52);
        this.btnQuick102.Size = new System.Drawing.Size(130, 25);
        this.btnQuick102.Text = "Sample #102";
        this.btnQuick102.UseVisualStyleBackColor = false;
        this.btnQuick102.Click += (s, e) => { this.txtSearch.Text = "102"; BtnSearch_Click(s, e); };

        // 
        // btnQuick103
        // 
        this.btnQuick103.BackColor = goldCream;
        this.btnQuick103.Font = new System.Drawing.Font("Segoe UI", 8F);
        this.btnQuick103.Location = new System.Drawing.Point(375, 81);
        this.btnQuick103.Size = new System.Drawing.Size(130, 25);
        this.btnQuick103.Text = "Sample #WTR-998811";
        this.btnQuick103.UseVisualStyleBackColor = false;
        this.btnQuick103.Click += (s, e) => { this.txtSearch.Text = "WTR-998811"; BtnSearch_Click(s, e); };

        // 
        // grpBillInfo
        // 
        this.grpBillInfo.Controls.Add(this.lblBillStatus);
        this.grpBillInfo.Controls.Add(this.lblBillStatusTitle);
        this.grpBillInfo.Controls.Add(this.lblDueDate);
        this.grpBillInfo.Controls.Add(this.lblDueDateTitle);
        this.grpBillInfo.Controls.Add(this.lblAmount);
        this.grpBillInfo.Controls.Add(this.lblAmountTitle);
        this.grpBillInfo.Controls.Add(this.lblAddress);
        this.grpBillInfo.Controls.Add(this.lblAddressTitle);
        this.grpBillInfo.Controls.Add(this.lblAccount);
        this.grpBillInfo.Controls.Add(this.lblAccountTitle);
        this.grpBillInfo.Controls.Add(this.lblCustName);
        this.grpBillInfo.Controls.Add(this.lblCustNameTitle);
        this.grpBillInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpBillInfo.Location = new System.Drawing.Point(20, 268);
        this.grpBillInfo.Name = "grpBillInfo";
        this.grpBillInfo.Size = new System.Drawing.Size(520, 175);
        this.grpBillInfo.TabIndex = 3;
        this.grpBillInfo.TabStop = false;
        this.grpBillInfo.Text = "2. Utility Bill Details";

        // Labels inside grpBillInfo
        this.lblCustNameTitle.Location = new System.Drawing.Point(15, 28);
        this.lblCustNameTitle.Size = new System.Drawing.Size(110, 20);
        this.lblCustNameTitle.Text = "Customer:";
        this.lblCustNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblCustName.Location = new System.Drawing.Point(130, 28);
        this.lblCustName.Size = new System.Drawing.Size(370, 20);
        this.lblCustName.Text = "--";
        this.lblCustName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

        this.lblAccountTitle.Location = new System.Drawing.Point(15, 52);
        this.lblAccountTitle.Size = new System.Drawing.Size(110, 20);
        this.lblAccountTitle.Text = "Account #:";
        this.lblAccountTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblAccount.Location = new System.Drawing.Point(130, 52);
        this.lblAccount.Size = new System.Drawing.Size(370, 20);
        this.lblAccount.Text = "--";
        this.lblAccount.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);

        this.lblAddressTitle.Location = new System.Drawing.Point(15, 76);
        this.lblAddressTitle.Size = new System.Drawing.Size(110, 20);
        this.lblAddressTitle.Text = "Address:";
        this.lblAddressTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblAddress.Location = new System.Drawing.Point(130, 76);
        this.lblAddress.Size = new System.Drawing.Size(370, 20);
        this.lblAddress.Text = "--";
        this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);

        this.lblAmountTitle.Location = new System.Drawing.Point(15, 102);
        this.lblAmountTitle.Size = new System.Drawing.Size(110, 24);
        this.lblAmountTitle.Text = "Amount Due:";
        this.lblAmountTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblAmount.Location = new System.Drawing.Point(130, 100);
        this.lblAmount.Size = new System.Drawing.Size(370, 24);
        this.lblAmount.Text = "LKR 0.00";
        this.lblAmount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
        this.lblAmount.ForeColor = accentRed; // #D0311E

        this.lblDueDateTitle.Location = new System.Drawing.Point(15, 130);
        this.lblDueDateTitle.Size = new System.Drawing.Size(110, 20);
        this.lblDueDateTitle.Text = "Due Date:";
        this.lblDueDateTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblDueDate.Location = new System.Drawing.Point(130, 130);
        this.lblDueDate.Size = new System.Drawing.Size(160, 20);
        this.lblDueDate.Text = "--";
        this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);

        this.lblBillStatusTitle.Location = new System.Drawing.Point(300, 130);
        this.lblBillStatusTitle.Size = new System.Drawing.Size(60, 20);
        this.lblBillStatusTitle.Text = "Status:";
        this.lblBillStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

        this.lblBillStatus.Location = new System.Drawing.Point(365, 130);
        this.lblBillStatus.Size = new System.Drawing.Size(130, 20);
        this.lblBillStatus.Text = "--";
        this.lblBillStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

        // 
        // grpPayment
        // 
        this.grpPayment.Controls.Add(this.btnSettle);
        this.grpPayment.Controls.Add(this.txtCashier);
        this.grpPayment.Controls.Add(this.lblCashier);
        this.grpPayment.Controls.Add(this.lblChangeAmount);
        this.grpPayment.Controls.Add(this.lblChange);
        this.grpPayment.Controls.Add(this.txtTendered);
        this.grpPayment.Controls.Add(this.lblTendered);
        this.grpPayment.Controls.Add(this.rbCard);
        this.grpPayment.Controls.Add(this.rbCash);
        this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpPayment.Location = new System.Drawing.Point(20, 453);
        this.grpPayment.Name = "grpPayment";
        this.grpPayment.Size = new System.Drawing.Size(520, 185);
        this.grpPayment.TabIndex = 4;
        this.grpPayment.TabStop = false;
        this.grpPayment.Text = "3. Cashier Tender & Settle";

        // 
        // rbCash
        // 
        this.rbCash.AutoSize = true;
        this.rbCash.Checked = true;
        this.rbCash.Location = new System.Drawing.Point(18, 28);
        this.rbCash.Text = "💵 Cash Tender";
        this.rbCash.CheckedChanged += new System.EventHandler(this.PaymentMethod_Changed);

        // 
        // rbCard
        // 
        this.rbCard.AutoSize = true;
        this.rbCard.Location = new System.Drawing.Point(160, 28);
        this.rbCard.Text = "💳 Cargills Card / POS Card";
        this.rbCard.CheckedChanged += new System.EventHandler(this.PaymentMethod_Changed);

        // 
        // lblTendered
        // 
        this.lblTendered.AutoSize = true;
        this.lblTendered.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblTendered.Location = new System.Drawing.Point(15, 62);
        this.lblTendered.Text = "Tendered (LKR):";

        // 
        // txtTendered
        // 
        this.txtTendered.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
        this.txtTendered.Location = new System.Drawing.Point(125, 59);
        this.txtTendered.Size = new System.Drawing.Size(130, 27);
        this.txtTendered.Text = "0.00";
        this.txtTendered.TextChanged += new System.EventHandler(this.TxtTendered_TextChanged);

        // 
        // lblChange
        // 
        this.lblChange.AutoSize = true;
        this.lblChange.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblChange.Location = new System.Drawing.Point(280, 62);
        this.lblChange.Text = "Change Due:";

        // 
        // lblChangeAmount
        // 
        this.lblChangeAmount.AutoSize = true;
        this.lblChangeAmount.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold);
        this.lblChangeAmount.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
        this.lblChangeAmount.Location = new System.Drawing.Point(375, 62);
        this.lblChangeAmount.Text = "LKR 0.00";

        // 
        // lblCashier
        // 
        this.lblCashier.AutoSize = true;
        this.lblCashier.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblCashier.Location = new System.Drawing.Point(15, 98);
        this.lblCashier.Text = "Cashier ID:";

        // 
        // txtCashier
        // 
        this.txtCashier.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtCashier.Location = new System.Drawing.Point(125, 95);
        this.txtCashier.Size = new System.Drawing.Size(180, 25);
        this.txtCashier.Text = "CSH-4092 (Kasun P.)";

        // 
        // btnSettle
        // 
        this.btnSettle.BackColor = accentRed; // #D0311E
        this.btnSettle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSettle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnSettle.ForeColor = System.Drawing.Color.White;
        this.btnSettle.Location = new System.Drawing.Point(15, 132);
        this.btnSettle.Size = new System.Drawing.Size(490, 42);
        this.btnSettle.Text = "✔ COLLECT & SETTLE BILL VIA NWSDB API";
        this.btnSettle.UseVisualStyleBackColor = false;
        this.btnSettle.Click += new System.EventHandler(this.BtnSettle_Click);

        // 
        // grpReceipt
        // 
        this.grpReceipt.Controls.Add(this.btnClearReceipt);
        this.grpReceipt.Controls.Add(this.rtbReceipt);
        this.grpReceipt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.grpReceipt.Location = new System.Drawing.Point(555, 122);
        this.grpReceipt.Name = "grpReceipt";
        this.grpReceipt.Size = new System.Drawing.Size(410, 516);
        this.grpReceipt.TabIndex = 5;
        this.grpReceipt.TabStop = false;
        this.grpReceipt.Text = "4. Thermal POS Receipt (Generated live)";

        // 
        // rtbReceipt
        // 
        this.rtbReceipt.BackColor = goldCream; // #F8EBAB
        this.rtbReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.rtbReceipt.Font = new System.Drawing.Font("Consolas", 9.5F);
        this.rtbReceipt.Location = new System.Drawing.Point(15, 28);
        this.rtbReceipt.ReadOnly = true;
        this.rtbReceipt.Size = new System.Drawing.Size(380, 435);
        this.rtbReceipt.TabIndex = 0;
        this.rtbReceipt.Text = "--- Standby for customer payment ---";

        // 
        // btnClearReceipt
        // 
        this.btnClearReceipt.BackColor = System.Drawing.Color.White;
        this.btnClearReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClearReceipt.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.btnClearReceipt.Location = new System.Drawing.Point(15, 473);
        this.btnClearReceipt.Size = new System.Drawing.Size(380, 32);
        this.btnClearReceipt.Text = "Clear Receipt Terminal";
        this.btnClearReceipt.UseVisualStyleBackColor = false;
        this.btnClearReceipt.Click += (s, e) => { this.rtbReceipt.Text = "--- Standby for customer payment ---"; };

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
        this.ClientSize = new System.Drawing.Size(984, 660);
        this.Controls.Add(this.grpReceipt);
        this.Controls.Add(this.grpPayment);
        this.Controls.Add(this.grpBillInfo);
        this.Controls.Add(this.grpLookup);
        this.Controls.Add(this.pnlStatus);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Cargills Food City — Utility Bill PayPoint Terminal (Decoupled SOA Client)";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlStatus.ResumeLayout(false);
        this.pnlStatus.PerformLayout();
        this.grpLookup.ResumeLayout(false);
        this.grpLookup.PerformLayout();
        this.grpBillInfo.ResumeLayout(false);
        this.grpPayment.ResumeLayout(false);
        this.grpPayment.PerformLayout();
        this.grpReceipt.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeaderTitle;
    private System.Windows.Forms.Label lblHeaderSubtitle;
    private System.Windows.Forms.Label lblBrandBadge;

    private System.Windows.Forms.Panel pnlStatus;
    private System.Windows.Forms.Label lblStatusNwsdb;
    private System.Windows.Forms.Label lblStatusBank;
    private System.Windows.Forms.Button btnCheckStatus;

    private System.Windows.Forms.GroupBox grpLookup;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Button btnRegisterCustomer;
    private System.Windows.Forms.Button btnQuick101;
    private System.Windows.Forms.Button btnQuick102;
    private System.Windows.Forms.Button btnQuick103;

    private System.Windows.Forms.GroupBox grpBillInfo;
    private System.Windows.Forms.Label lblCustNameTitle;
    private System.Windows.Forms.Label lblCustName;
    private System.Windows.Forms.Label lblAccountTitle;
    private System.Windows.Forms.Label lblAccount;
    private System.Windows.Forms.Label lblAddressTitle;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.Label lblAmountTitle;
    private System.Windows.Forms.Label lblAmount;
    private System.Windows.Forms.Label lblDueDateTitle;
    private System.Windows.Forms.Label lblDueDate;
    private System.Windows.Forms.Label lblBillStatusTitle;
    private System.Windows.Forms.Label lblBillStatus;

    private System.Windows.Forms.GroupBox grpPayment;
    private System.Windows.Forms.RadioButton rbCash;
    private System.Windows.Forms.RadioButton rbCard;
    private System.Windows.Forms.Label lblTendered;
    private System.Windows.Forms.TextBox txtTendered;
    private System.Windows.Forms.Label lblChange;
    private System.Windows.Forms.Label lblChangeAmount;
    private System.Windows.Forms.Label lblCashier;
    private System.Windows.Forms.TextBox txtCashier;
    private System.Windows.Forms.Button btnSettle;

    private System.Windows.Forms.GroupBox grpReceipt;
    private System.Windows.Forms.RichTextBox rtbReceipt;
    private System.Windows.Forms.Button btnClearReceipt;
}
