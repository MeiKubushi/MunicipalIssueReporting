using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalIssueReporting
{
    public partial class ReportIssueForm : Form
    {
        public static List<Issue> AllReportedIssues = new List<Issue>();

        private TextBox txtLocation;
        private ComboBox cmbCategory;
        private RichTextBox rtbDescription;
        private TextBox txtAttachment;
        private string selectedAttachmentPath = "";

        public ReportIssueForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Report an Issue — Municipal Services";
            this.Size = new Size(550, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;

            int y = 20;

            AddLabel("📍 Location / Address", 20, y);
            y += 25;
            txtLocation = new TextBox { Location = new Point(20, y), Size = new Size(490, 30), Font = new Font("Arial", 11) };
            this.Controls.Add(txtLocation);
            y += 40;

            AddLabel("🏷️ Category", 20, y);
            y += 25;
            cmbCategory = new ComboBox { Location = new Point(20, y), Size = new Size(490, 30), Font = new Font("Arial", 11), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.Items.AddRange(new[] { "Sanitation", "Roads & Infrastructure", "Electricity / Power", "Water & Sewage", "Waste Management", "Public Parks", "Other" });
            cmbCategory.SelectedIndex = 0;
            this.Controls.Add(cmbCategory);
            y += 40;

            AddLabel("📝 Description of Issue", 20, y);
            y += 25;
            rtbDescription = new RichTextBox { Location = new Point(20, y), Size = new Size(490, 120), Font = new Font("Arial", 11) };
            this.Controls.Add(rtbDescription);
            y += 130;

            AddLabel("📎 Attach Image / Document (Optional)", 20, y);
            y += 25;
            txtAttachment = new TextBox { Location = new Point(20, y), Size = new Size(380, 30), Font = new Font("Arial", 10), ReadOnly = true, BackColor = Color.White };
            this.Controls.Add(txtAttachment);
            Button btnBrowse = new Button { Text = "Browse...", Location = new Point(410, y), Size = new Size(100, 30), BackColor = Color.LightGray };
            btnBrowse.Click += BtnBrowse_Click;
            this.Controls.Add(btnBrowse);
            y += 50;

            Button btnSubmit = new Button { Text = "✅ Submit Report", Location = new Point(280, y), Size = new Size(230, 45), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, Font = new Font("Arial", 12, FontStyle.Bold) };
            btnSubmit.Click += BtnSubmit_Click;
            this.Controls.Add(btnSubmit);

            Button btnBack = new Button { Text = "← Back", Location = new Point(20, y), Size = new Size(200, 45), BackColor = Color.LightGray };
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);
        }

        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label { Text = text, Location = new Point(x, y), Font = new Font("Arial", 11, FontStyle.Bold), AutoSize = true };
            this.Controls.Add(lbl);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Select Image or Document";
                open.Filter = "Allowed Files|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    selectedAttachmentPath = open.FileName;
                    txtAttachment.Text = Path.GetFileName(selectedAttachmentPath);
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("⚠️ Please enter the location of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("⚠️ Please provide a description of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            Issue newIssue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = selectedAttachmentPath,
                ReportedAt = DateTime.Now
            };
            AllReportedIssues.Add(newIssue);

            MessageBox.Show($"✅ Report submitted!\n\nReference: #{AllReportedIssues.Count}\nThank you!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtLocation.Clear();
            cmbCategory.SelectedIndex = 0;
            rtbDescription.Clear();
            txtAttachment.Clear();
            selectedAttachmentPath = "";
        }
    }
}