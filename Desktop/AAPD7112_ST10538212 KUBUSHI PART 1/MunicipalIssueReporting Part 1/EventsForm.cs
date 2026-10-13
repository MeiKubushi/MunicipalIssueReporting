using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MunicipalIssueReporting
{


    public partial class EventsForm : Form
    {
        // ✅ SortedDictionary — automatically organises events by date
        private SortedDictionary<DateTime, List<EventItem>> _eventsByDate= null!;

        private ListBox _lstEvents= null!;
        private ComboBox _cmbCategory= null!;
        private DateTimePicker _dtpSearchDate= null!;
        private Label _lblResultCount= null!;

        public EventsForm()
        {
            InitializeComponent();
            _eventsByDate = new SortedDictionary<DateTime, List<EventItem>>();
            LoadSampleEvents();
            DisplayAllEvents();
        }

        private void InitializeComponent()
        {
            this.Text = "📅 Local Events & Announcements";
            this.Size = new Size(720, 620);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // --- Header ---
            Label lblHeader = new Label
            {
                Text = "Upcoming Local Events & Announcements",
                Font = new Font("Arial", 13, FontStyle.Bold),
                Location = new Point(160, 15),
                AutoSize = true
            };
            this.Controls.Add(lblHeader);

            // --- Search Controls ---
            Label lblCategory = new Label { Text = "Category:", Location = new Point(30, 75), AutoSize = true, Font = new Font("Arial", 10) };
            _cmbCategory = new ComboBox
            {
                Location = new Point(110, 72),
                Size = new Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10)
            };
            _cmbCategory.Items.AddRange(new[] { "All", "Community", "Meeting", "Roadworks", "Emergency", "Festival" });

            Label lblDate = new Label { Text = "Date:", Location = new Point(320, 75), AutoSize = true, Font = new Font("Arial", 10) };
            _dtpSearchDate = new DateTimePicker
            {
                Location = new Point(370, 72),
                Size = new Size(170, 28),
                Font = new Font("Arial", 10)
            };

            Button btnSearch = new Button
            {
                Text = "🔍 Search",
                Location = new Point(560, 70),
                Size = new Size(95, 32),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.Click += BtnSearch_Click;

            // --- Back Button ---
Button btnBack = new Button
{
    Text = "🏠 Back to Home",
    Location = new Point(520, 500),
    Size = new Size(140, 35),
    BackColor = Color.FromArgb(149, 165, 166),
    ForeColor = Color.White,
    FlatStyle = FlatStyle.Flat,
    Cursor = Cursors.Hand, // 💡 Nice touch: shows it's clickable
    TextAlign = ContentAlignment.MiddleCenter
};

// Optional: Remove default border for cleaner look
btnBack.FlatAppearance.BorderSize = 2;

// Click event — closes current form
btnBack.Click += (s, e) => this.Close();

this.Controls.Add(btnBack); 

            Button btnShowAll = new Button
            {
                Text = "Show All Events",
                Location = new Point(30, 115),
                Size = new Size(160, 32),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnShowAll.Click += (s, e) => { DisplayAllEvents(); _cmbCategory.SelectedIndex = 0; };

            this.Controls.AddRange(new Control[] { lblCategory, _cmbCategory, lblDate, _dtpSearchDate, btnSearch, btnShowAll });

            // --- Events List ---
            _lstEvents = new ListBox
            {
                Location = new Point(30, 165),
                Size = new Size(680, 320),
                Font = new Font("Consolas", 9),
                BackColor = Color.White
            };
            this.Controls.Add(_lstEvents);

            // --- Result Counter ---
            _lblResultCount = new Label
            {
                Text = "",
                Location = new Point(30, 520),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                ForeColor = Color.Green
            };
            this.Controls.Add(_lblResultCount);
        }

        // ✅ Add sample events into SortedDictionary
        private void LoadSampleEvents()
        {
            AddEvent(new EventItem
            {
                Title = "Community Clean-Up — Soweto",
                Category = "Community",
                Date = new DateTime(2026, 10, 18),
                Location = "Vilakazi Street, Soweto",
                Description = "Join residents for a neighbourhood clean-up. Gloves & bags provided!"
            });

            AddEvent(new EventItem
            {
                Title = "Rivonia Road Resurfacing",
                Category = "Roadworks",
                Date = new DateTime(2026, 10, 22),
                Location = "Sandton, Rivonia Road",
                Description = "Lane closures 09:00–15:00. Please plan travel accordingly."
            });

            AddEvent(new EventItem
            {
                Title = "Ward 12 Public Meeting",
                Category = "Meeting",
                Date = new DateTime(2026, 10, 25),
                Location = "Johannesburg City Hall",
                Description = "Discuss service delivery & budget — all residents welcome."
            });

            AddEvent(new EventItem
            {
                Title = "Scheduled Power Outage — Braamfontein",
                Category = "Emergency",
                Date = new DateTime(2026, 10, 15),
                Location = "Braamfontein",
                Description = "⚠️ Essential upgrades: 08:00–14:00. Save your work!"
            });

            AddEvent(new EventItem
            {
                Title = "Heritage Day Festival",
                Category = "Festival",
                Date = new DateTime(2026, 11, 20),
                Location = "Orlando Stadium",
                Description = "Music, food & cultural celebration — free entry!"
            });

            _cmbCategory.SelectedIndex = 0;
        }

        private void AddEvent(EventItem ev)
        {
            if (!_eventsByDate.ContainsKey(ev.Date))
                _eventsByDate[ev.Date] = new List<EventItem>();

            _eventsByDate[ev.Date].Add(ev);
        }

        //  Automatically sorted by date via SortedDictionary
        private void DisplayAllEvents()
        {
            _lstEvents.Items.Clear();
            _lstEvents.Items.Add("═══════════════════════════════════════════════════════════════════════");
            _lstEvents.Items.Add("📅 ALL UPCOMING EVENTS (Sorted by Date)");
            _lstEvents.Items.Add("═══════════════════════════════════════════════════════════════════════");

            foreach (var dateGroup in _eventsByDate)
            {
                foreach (var ev in dateGroup.Value)
                {
                    _lstEvents.Items.Add($"📅 {ev.Date:yyyy-MM-dd}  |  {ev.Category.ToUpper(),-12}  |  {ev.Title}");
                    _lstEvents.Items.Add($"   📍 {ev.Location}");
                    _lstEvents.Items.Add($"   ℹ️ {ev.Description}");
                    _lstEvents.Items.Add("───────────────────────────────────────────────────────────────────────");
                }
            }

            int total = _eventsByDate.Values.SelectMany(g => g).Count();
            _lblResultCount.Text = $"✅ Showing {total} event(s)";
        }

        // ✅ Search by Category AND Date
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _lstEvents.Items.Clear();
            string selectedCat = _cmbCategory.SelectedItem?.ToString() ?? "All";
            DateTime selectedDate = _dtpSearchDate.Value.Date;
            List<EventItem> matches = new List<EventItem>();

            _lstEvents.Items.Add("═══════════════════════════════════════════════════════════════════════");
            _lstEvents.Items.Add($"🔍 SEARCH — Category: {(selectedCat == "All" ? "Any" : selectedCat)} | Date: {selectedDate:yyyy-MM-dd}");
            _lstEvents.Items.Add("═══════════════════════════════════════════════════════════════════════");

            foreach (var dateGroup in _eventsByDate)
            {
                foreach (var ev in dateGroup.Value)
                {
                    bool catOk = selectedCat == "All" || ev.Category == selectedCat;
                    bool dateOk = ev.Date.Date == selectedDate;

                    if (catOk && dateOk)
                        matches.Add(ev);
                }
            }

            if (matches.Any())
            {
                foreach (var ev in matches)
                {
                    _lstEvents.Items.Add($"📅 {ev.Date:yyyy-MM-dd}  |  {ev.Category.ToUpper(),-12}  |  {ev.Title}");
                    _lstEvents.Items.Add($"   📍 {ev.Location}");
                    _lstEvents.Items.Add($"   ℹ️ {ev.Description}");
                    _lstEvents.Items.Add("───────────────────────────────────────────────────────────────────────");
                }
                _lblResultCount.Text = $"✅ {matches.Count} match(es) found";
            }
            else
            {
                _lstEvents.Items.Add("❌ No events match your search criteria.");
                _lblResultCount.Text = "⚠️ 0 matches found";
            }
        }
    }
}