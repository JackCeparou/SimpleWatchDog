Modify sample SimpleWatchDog.exe.config values to what you use.

One `<watchDog ... />` line per watcher.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="WatchDogConfig" type="SimpleWatchDog.Configuration.WatchDogConfig, SimpleWatchDog" allowLocation="true" allowDefinition="Everywhere" />
  </configSections>
  <WatchDogConfig>
    <watchDogs>
      <watchDog runningProcessName="MUST_RUN" watchProcessName="TOOL_TO_LAUNCH" launchPath="C:\PATH\TO\TOOL_TO_LAUNCH.exe" timer="1000"/>
      <watchDog runningProcessName="MUST_RUN2" watchProcessName="TOOL_TO_LAUNCH2" launchPath="C:\PATH\TO\TOOL_TO_LAUNCH2.exe" timer="2000"/>
    </watchDogs>
  </WatchDogConfig>
</configuration>
```

e.g.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="WatchDogConfig" type="SimpleWatchDog.Configuration.WatchDogConfig, SimpleWatchDog" allowLocation="true" allowDefinition="Everywhere" />
  </configSections>
  <WatchDogConfig>
    <watchDogs>
      <watchDog runningProcessName="Diablo III" watchProcessName="Turbo" launchPath="C:\PATH\TO\Turbo.exe" timer="1000"/>
      <watchDog runningProcessName="Diablo III64" watchProcessName="Turbo64" launchPath="C:\PATH\TO64\Turbo64.exe" timer="1000"/>
    </watchDogs>
  </WatchDogConfig>
</configuration>
```