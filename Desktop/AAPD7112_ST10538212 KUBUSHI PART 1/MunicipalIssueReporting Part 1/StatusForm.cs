using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalIssueReporting
{
    public partial class StatusForm : Form
    {
        private TextBox txtReference;
        private Button btnSearch;
        private Label lblResult;

        public StatusForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "🔍 Service Request Status";
            this.Size = new Size(550, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;

            int y = 20;

            // Title
            AddLabel("🔍 Check Request Status", 20, y, 16, FontStyle.Bold);
            y += 40;

            // Instruction
            AddLabel("Enter your Reference Number below:", 20, y, 11);
            y += 30;

            // Reference Input
            AddLabel("Reference #:", 20, y);
            txtReference = new TextBox
            {
                Location = new Point(110, y),
                Size = new Size(300, 30),
                Font = new Font("Arial", 11),
                PlaceholderText = "e.g. 1, 2, 3..."
            };
            this.Controls.Add(txtReference);

            btnSearch = new Button
            {
                Text = "🔍 Search",
                Location = new Point(420, y),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);
            y += 50;

            // Result Display
            lblResult = new Label
            {
                Location = new Point(20, y),
                Size = new Size(490, 150),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 10),
                Padding = new Padding(12),
                Text = "Enter a reference number and click Search.\n\nReference numbers are shown when you submit a report."
            };
            this.Controls.Add(lblResult);

            // Back Button
            Button btnBack = new Button
            {
                Text = "← Back",
                Location = new Point(390, 300),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 11)
            };
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);
        }

        private void AddLabel(string text, int x, int y, int fontSize = 11, FontStyle style = FontStyle.Regular)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Font = new Font("Arial", fontSize, style),
                AutoSize = true
            };
            this.Controls.Add(lbl);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            lblResult.Text = "";

            if (!int.TryParse(txtReference.Text.Trim(), out int refNum) || refNum < 1)
            {
                lblResult.Text = "⚠️ Please enter a valid reference number.\n\nExample: Enter 1 for your first report.";
                lblResult.BackColor = Color.FromArgb(255, 248, 240);
                return;
            }

            var list = ReportIssueForm.AllReportedIssues;
            if (refNum > list.Count)
            {
                lblResult.Text = $"❌ Reference #{refNum} NOT FOUND.\n\nTotal reports submitted: {list.Count}\n\nMake sure you submitted the report first.";
                lblResult.BackColor = Color.FromArgb(255, 240, 240);
                return;
            }

            // Found — show details
            var issue = list[refNum - 1];
            string[] statuses = { "🔵 Received — Pending Review", "🟡 In Progress — Assigned", "🟢 Resolved — Completed" };
            string status = statuses[(refNum - 1) % 3];

            lblResult.BackColor = Color.FromArgb(240, 255, 245);
            lblResult.Text =
                $"✅ Reference #{refNum} — FOUND!\n\n" +
                $"📍 Location: {issue.Location}\n" +
                $"🏷️ Category: {issue.Category}\n" +
                $"📅 Submitted: {issue.ReportedAt:yyyy-MM-dd HH:mm}\n" +
                $"📝 Description: {issue.Description}\n" +
                $"📎 Attachment: {(string.IsNullOrEmpty(issue.AttachmentPath) ? "None" : "Attached")}\n" +
                $"🚦 Status: {status}";
        }
    }
}