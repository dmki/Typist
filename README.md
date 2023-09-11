# Typist: Windows Client and WebAPI Backend Application

## Description

Typist is a standalone Windows client paired with a WebAPI backend. Its primary function is to allow users to post text messages that the API retains for a brief duration (one minute). By triggering a specific keyboard combination on your PC, the Typist client fetches the stored message from the API and types it out in the currently active window.

## Key Features

- **Realistic Typing Simulation**: Unlike conventional copy-pasting, the Typist client mimics manual keystrokes at variable speeds. This makes it appear as though you're genuinely typing the content, which can be particularly beneficial if someone is monitoring your screen.

- **Practical Use Cases**: One of the popular applications of Typist is to transcribe responses from the ILEXA Telegram bot ([https://t.me/ilexabot](https://t.me/ilexabot)), especially during scenarios such as online exams or customer support sessions.

- **Stealth Mode**: The application can be made inconspicuous, disappearing from your view, although it remains visible in the Task Manager. You can also set it to automatically close after a specified time period.

- **Unique ID System for Data Transfer**: When transmitting and retrieving data from the API, a shared unique ID is required. In the context of ILEXA, the bot generates and shares this ID with you, ensuring seamless integration with Typist.

- **Data Privacy and Security**: The API does not permanently store your messages. Instead, it briefly holds them in RAM for only one minute, ensuring that your information isn't saved long-term.

> **Note**: Ensure that you input the shared unique ID correctly both when posting and fetching data from the API to make the most of Typist.
