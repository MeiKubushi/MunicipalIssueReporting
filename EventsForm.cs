using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalIssueReporting
{
    public partial class EventsForm : Form
    {
        // Sample events data — you can add more!
        private List<EventItem> allEvents = new List<EventItem>
        {
            new EventItem
            {
                Title = "Community Clean-Up Day",
                Date = new DateTime(2026, 9, 15),
                Time = "08:00 - 12:00",
                Location = "Johannesburg Park, Main Street",
                Category = "Community",
                Description = "Join neighbours and local officials to clean up our public park. Gloves and bags provided!"
            },
            new EventItem
            {
                Title = "Water Restriction Announcement",
                Date = new DateTime(2026, 9, 5),
                Time = "All Day",
                Location = "Whole Municipality",
                Category = "Announcement",
                Description = "Water pressure will be reduced due to reservoir maintenance. Please store water where possible."
            },
            new EventItem
            {
                Title = "Public Health Awareness Workshop",
                Date = new DateTime(2026, 9, 20),
                Time = "10:00 - 14:00",
                Location = "Community Hall, 4th Avenue",
                Category = "Health",
                Description = "Free health tips, screening, and information sessions. Open to all residents."
            },
            new EventItem
            {
                Title = "Road Works — Road Closure Notice",
                Date = new DateTime(2026, 9, 10),
                Time = "07:00 - 17:00",
                Location = "Church Street between 2nd & 3rd",
                Category = "Infrastructure",
                Description = "Resurfacing works in progress. Please use alternative routes. Expect delays."
            }
        };

        private ListView lstEvents;
        private ComboBox cmbFilter;
        private Label lblDetails;

        public EventsForm()
        {
            InitializeComponent();
            LoadEventsToListView();
        }

        private void InitializeComponent()
        {
            this.Text = "📅 Local Events and Announcements";
            this.Size = new Size(780, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;

            int y = 15;

            // --- Title ---
            AddLabel("📅 Local Events & Announcements", 20, y, 16, FontStyle.Bold);
            y += 35;

            // --- Filter Dropdown ---
            AddLabel("Filter by Category:", 20, y);
            y += 22;
            cmbFilter = new ComboBox
            {
                Location = new Point(20, y),
                Size = new Size(300, 30),
                Font = new Font("Arial", 11),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbFilter.Items.AddRange(new[] { "All Categories", "Community", "Announcement", "Health", "Infrastructure" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += CmbFilter_SelectedIndexChanged;
            this.Controls.Add(cmbFilter);
            y += 45;

            // --- Events List ---
            lstEvents = new ListView
            {
                Location = new Point(20, y),
                Size = new Size(690, 220),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Arial", 10)
            };
            lstEvents.Columns.Add("Date", 100);
            lstEvents.Columns.Add("Title", 230);
            lstEvents.Columns.Add("Category", 130);
            lstEvents.Columns.Add("Location", 200);
            lstEvents.SelectedIndexChanged += LstEvents_SelectedIndexChanged;
            this.Controls.Add(lstEvents);
            y += 235;

            // --- Details Panel ---
            AddLabel("📋 Event Details", 20, y, 12, FontStyle.Bold);
            y += 25;
            lblDetails = new Label
            {
                Location = new Point(20, y),
                Size = new Size(690, 110),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 10),
                Padding = new Padding(10),
                Text = "Select an event above to view details..."
            };
            this.Controls.Add(lblDetails);

            // --- Back Button ---
            Button btnBack = new Button
            {
                Text = "← Back to Main Menu",
                Location = new Point(510, 430),
                Size = new Size(200, 40),
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

        private void LoadEventsToListView(string categoryFilter = "All Categories")
        {
            lstEvents.Items.Clear();

            var filtered = categoryFilter == "All Categories"
                ? allEvents
                : allEvents.Where(e => e.Category == categoryFilter).ToList();

            foreach (var evt in filtered)
            {
                ListViewItem item = new ListViewItem(evt.Date.ToString("yyyy-MM-dd"));
                item.SubItems.Add(evt.Title);
                item.SubItems.Add(evt.Category);
                item.SubItems.Add(evt.Location);
                item.Tag = evt;
                lstEvents.Items.Add(item);
            }
        }

        private void CmbFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem != null)
                LoadEventsToListView(cmbFilter.SelectedItem.ToString());
        }

        private void LstEvents_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstEvents.SelectedItems.Count == 0)
            {
                lblDetails.Text = "Select an event above to view details...";
                return;
            }

            if (lstEvents.SelectedItems[0].Tag is EventItem evt)
            {
                lblDetails.Text =
                    $"📌 Title: {evt.Title}\n" +
                    $"📅 Date: {evt.Date:dddd, dd MMMM yyyy}\n" +
                    $"⏰ Time: {evt.Time}\n" +
                    $"📍 Location: {evt.Location}\n" +
                    $"🏷️ Category: {evt.Category}\n" +
                    $"📝 Description: {evt.Description}";
            }
        }
    }
}