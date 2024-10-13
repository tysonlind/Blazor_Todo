# Simple Blazor Application

### Parts
- Server side rendering todo application
- Server side API call for TikTok API that returns insights of the top 8 trending TikToks at any given moment
- Client side rendered blazor page that just shows some date when you click it

### Challenges
The biggest challenge I faced in building this was in deciding which rendering mode to use for each part of the application. Ultimately, I decided that I would follow similar guidelines to most frontend frameworks and render server-side where possible but reserve client side rendering for components or pages requiring extensive user input and interaction.

## Set up the project locally
To set up this project, you'll need:
- A tiktok Rapid API key set up under the key "TikTok" in your appsettings.json file
- A tiktok Host set up under the "TikTok" key as well in appsettings.json

Once you've installed the necessary packages and downloaded the project you should be able to just run it from that point.

Feel free to reach out if you have any trouble and happy coding
