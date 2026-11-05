# AutoAddder

**A Windows desktop automation tool built with C# and Windows Forms.**

AutoAddder is a desktop application designed to automate selected Telegram-related workflows through a combination of desktop interaction, image recognition, OCR, and external service integrations.

The project brings together several automation technologies in one interface, with configurable settings and workflow controls.

---

## ✨ Features

- **Telegram Desktop Integration** — Interacts with the Telegram desktop application.
- **Desktop Automation** — Uses mouse, keyboard, and Windows interface interaction.
- **VPN Integration** — Supports integration with VyprVPN and CyberVPN.
- **SMS Service Integration** — Connects to an external SMS activation service.
- **OCR Recognition** — Uses IronOCR for text recognition.
- **Image Processing** — Uses AForge.NET for image-related processing.
- **Configurable Automation** — Supports configurable screen coordinates and application settings.
- **Workflow Modes** — Includes Adding, Authorizing, and Leave modes.
- **Progress Monitoring** — Provides a Windows Forms interface for managing and monitoring workflows.

## 🛠️ Built With

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| Windows Forms | Desktop user interface |
| .NET Framework | Application framework |
| IronOCR | Optical character recognition |
| AForge.NET | Image processing |
| Windows API | Desktop interaction |
| WebClient | HTTP communication |
| Nancy.Json | JSON handling |

## 📁 Project Structure

```text
AutoAddder/
│
├── Form1.cs
│   └── Main application logic
│
├── Form1.Designer.cs
│   └── Windows Forms interface components
│
└── README.md
    └── Project documentation
```

## ⚙️ Configuration

The application uses configurable components for its integrations and desktop environment, including:

- Telegram Desktop installation and profile directories.
- VPN application paths.
- Screen coordinates and desktop interaction settings.
- OCR configuration.
- External service credentials.

Configuration and credentials should be stored securely and never committed directly to a public repository.

## 💻 Requirements

- Windows operating system.
- Visual Studio with C# and Windows Forms support.
- Required project dependencies.
- Telegram Desktop.
- Compatible VPN software for the VPN integrations.
- Valid credentials for any external services used.

*The exact framework target and dependency versions should be verified against the project configuration.*

## 🔐 Security & Responsible Use

This project interacts with desktop applications and external services. Use it only with accounts and systems you are authorized to access.

- Keep API keys and credentials private.
- Never publish personal account information or access tokens.
- Follow Telegram's Terms of Service and applicable platform policies.
- Respect the terms of third-party services.
- Use responsibly and in compliance with applicable laws.

**Important:** Remove any hardcoded API keys from the source code and rotate exposed credentials before making the repository public.

## 📌 Project Status

AutoAddder is a C# Windows desktop automation project combining multiple technologies into a single application.

## 👨‍💻 Author

Developed in **C#**.

---

*If you find this project useful, feel free to explore the source code and learn more about its implementation.*
