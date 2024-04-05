# SCP-Left-Notification
- When a SCP Lefts it will send a notification to all avaialable admins, showing them.
- The SCP get's replaced by a spectator.

# Installation
```
Install in Exiled -> Plugins
```
```
Install Newtonsoft.json in Exiled -> Plugins -> dependencies
```
```
Config is in Exiled -> Configs -> Your_Server_Port_Config -> SCPLeftNotif
```

# Plugin is meant for version of Exiled 8.8.0


# Images

![image](https://github.com/Adyman0010/SCP-Left-Notification/assets/139592888/e2d8915e-dd88-4103-a948-5aa1ec7f46cb)


![image](https://github.com/Adyman0010/SCP-Left-Notification/assets/139592888/d919a78c-44ea-4d07-860a-66828b3f603e)


![image](https://github.com/Adyman0010/SCP-Left-Notification/assets/139592888/3cf67756-b6d9-4b19-9414-caf1649344d6)


# Config

```
SCPLeftNotif:
  is_enabled: true
  debug: false
  # What message should brodcast to admins, when SCP leaves
  admin_message: 'A Player left as a SCP! Check your console by pressing ;'
  # The message to send in the console (DO NOT delete any of the %% otherwise it will result in plugin not working properly)
  console_message: 'Player %name% left! ID: %userid%, ROLE: %role%'
  # True/False If you want to use Discord Webhook (default: true)
  use_web_hook: true
  # In the '' you will insert a Discord WebHook (If you want to use this featuer ofcourse) 
  web_hook: ''
```
