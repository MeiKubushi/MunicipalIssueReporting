using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalIssueReporting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyEngagementStrategy();
        }
        private void BtnEvents_Click(object? sender, EventArgs e)
        {
            EventsForm eventsForm = new EventsForm();
            eventsForm.ShowDialog();
        }
        private void BtnStatus_Click(object? sender, EventArgs e)
        {
            StatusForm statusForm = new StatusForm();
            statusForm.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.Text = "Municipal Services — Report an Issue";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Label lblTitle = new Label
            {
                Text = "Municipal Services Portal",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(120, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            Label lblSub = new Label
            {
                Text = "Please select an option below",
                Font = new Font("Arial", 10),
                Location = new Point(140, 60),
                AutoSize = true
            };
            this.Controls.Add(lblSub);

            Button btnReport = new Button
            {
                Text = "📝 Report Issues",
                Size = new Size(300, 50),
                Location = new Point(80, 110),
                Font = new Font("Arial", 12),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };
            btnReport.Click += BtnReport_Click;
            this.Controls.Add(btnReport);

            Button btnEvents = new Button
            {
                Text = "📅 Local Events and Announcements",
                Size = new Size(300, 50),
                Location = new Point(80, 180),
                Font = new Font("Arial", 12),
                Enabled = true,
                BackColor = Color.FromArgb(52, 152, 219)
            };
            btnEvents.Click += BtnEvents_Click;
            this.Controls.Add(btnEvents);

            Button btnStatus = new Button
            {
                Text = "🔍 Service Request Status",
                Size = new Size(300, 50),
                Location = new Point(80, 250),
                Font = new Font("Arial", 12),
                Enabled = true,
                BackColor = Color.FromArgb(52, 152, 219)
            };
            this.Controls.Add(btnStatus);
            btnStatus.Click += BtnStatus_Click; 
            
        }

        private void ApplyEngagementStrategy()
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.ShowDialog();
        }
    }
}