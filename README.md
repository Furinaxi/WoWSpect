
# WoWSpect

This project was created as part of a student project.

**WoWspect is a desktop application to look up player and guild information outside of Blizzard Entertainment's World Of Warcraft.**

It uses Blizzard's official API to stay up to date with the current expansions and their respective data.


## Usage
To use this application, you need to create your own client at [Blizzard's development portal](https://develop.battle.net/access/clients).

After creating the client, you need to set the client ID and the client secret in the settings in order to generate the access token used for requests.

When it's all done and set, you can look up players and guilds.

If a player or a guild cannot be found after a while, re-save your settings to generate a new access token.

Multiple words need to be separated with a hyphen (-).  
"Argent Dawn" should be written as "Argent-Dawn".

***Please note that the Chinese region is not supported.***

### Region Abbreviations

| Region  | Abbreviation |
|---|---|
| North America  |  us |
|  Europe |  eu |
| Korea  | kr  |
|  Taiwan | tw  |
