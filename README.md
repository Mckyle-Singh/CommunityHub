# Community Hub

**Community Hub** is a modular Windows Forms application built to empower South African municipalities and civic organizations with tools for citizen engagement, service transparency, and public accountability.

---

## 🧭 Features

- **Report Issues**  
  Citizens can submit location-based reports with descriptions and photos—ideal for potholes, water leaks, or broken infrastructure.

- **Local Events & Announcements**  
  A scrollable feed of community events, safety notices, and municipal updates.  
  Includes:
  - **Event Queueing**: Events are stored and managed using a queue for chronological display.
  - **Category Tagging**: Events are color-coded by category (e.g., Volunteer, Public Notice, Government) for quick visual filtering.
  - **Search Tracking**: User search patterns are tracked using dictionaries to identify frequently searched categories and keywords.
  - **Smart Recommendations**: Suggests relevant events based on user behavior using frequency-based filtering and keyword relevance.
  - **Insights Panel**: Displays unique categories and dates using sets, with tag buttons and a date summary grid for quick navigation.


- **Service Request Status**  
  Citizens can track the progress of their submitted service requests in real time. Each request displays a visual timeline showing key milestones, such as submission, department assignment, in-progress updates, and completion. Users can see      which municipal department is responsible for handling the issue and receive feedback notifications once updates are made. This feature helps improve transparency and accountability, allowing residents to stay informed about infrastructure      repairs, public works, or other civic concerns. Internally, requests are stored in a list of report objects, and the UI dynamically updates timelines and status indicators as new updates are logged.
---

## 🛠️ Tech Stack

- **C# / .NET Framework**  
- **Windows Forms (WinForms)**  
- **Git + GitHub for version control**  

---

## 🚀 Getting Started

1. Open Visual studio
2. Click "Clone repository"
3. Paste the following link in the repository location field :
   ```bash
   git clone https://github.com/Mckyle-Singh/CommunityHub.git

4. Build the solution (Ctrl+Shift+B or Build > Build Solution).

5. Run the application (F5 or Debug > Start Debugging).
