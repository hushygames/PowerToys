## Install tests
 * install a **previous version** on a clean machine (a clean machine doesn't have the `%localappdata%\Microsoft\PowerToys` folder)
 * open the Settings and for each module change at least one option
 * open the FancyZones editor and create two custom layouts:
    * a canvas layout with 2 zones, use unicode chars in the layout's name
    * one from grid template using 4 zones and splitting one zone
    * apply the custom canvas layout to the primary desktop
    * create a virtual desktop and apply the custom grid layout
    * if you have a second monitor apply different templates layouts for the primary desktop and for the second virtual desktop
 * install the new version (it will uninstall the old version and install the new version)
 - [x] verify the settings are preserved and FancyZones configuration is still the same
 - [x] test installing as SYSTEM (LocalSystem account)
   * Download PsTools from https://learn.microsoft.com/en-us/sysinternals/downloads/psexec
   * Run PowerToys installer with psexec tool `psexec.exe -sid <path_to_installer_exe`
   * Brief check if all modules are working

 * PER-USER and PER-MACHINE TESTS:
   * Install **previous version** on a clean machine and update with new per-machine version. Ensure that it is installed in Program files and that registry entries are under **HKLM**/Software/Classes/PowerToys. Go trhough different modules and ensure that they are working correctly.
   * Try installing per-user version over already installed per-machine version and ensure that proper error message is shown.
   * Remove PowerToys and install per-user version. Ensure that it is installed in <APPDATA>/Local/PowerToys and that registry entries are under **HKCU**/Software/Classes/PowerToys. Go trhough different modules and ensure that they are working correctly.
   * Create a new user and install per-user version there as well. Go trhough different modules and ensure that they are working correctly. Ensure that changing settings for one user does not change settings of other user.

## Functional tests

 Regressions:
 - [x] https://github.com/microsoft/PowerToys/issues/1414#issuecomment-593529038
 - [x] https://github.com/microsoft/PowerToys/issues/1524

## General Settings

**Admin mode:**
 - [x] restart PT and verify it runs as user
 - [x] restart as admin and set "Always run as admin"
 - [x] restart PT and verify it  runs as admin
 * if it's not on, turn on "Run at startup"
 - [x] reboot the machine and verify PT runs as admin (it should not prompt the UAC dialog)
 * turn Always run as admin" off
 - [x] reboot the machine and verify it now runs as user

**Modules on/off:**
 - [x] turn off all the modules and verify all module are off
 - [x] restart PT and verify that all module are still off in the settings page and they are actually inactive
 - [x] turn on all the module, all module are now working
 - [x] restart PT and verify that all module are still on in the settings page and they are actually working

**Quick access tray icon flyout:**
 - [x] Use left click on the system tray icon and verify the flyout appears. (It'll take a bit the first time)
 - [x] Try to launch a module from the launch screen in the flyout.
 - [x] Try disabling a module in the all apps screen in the flyout, make it a module that's launchable from the launch screen. Verify that the module is disabled and that it also disappeared from the launch screen in the flyout.
 - [x] Open the main settings screen on a module page. Verify that when you disable/enable the module on the flyout, that the Settings page is updated too.

**Settings backup/restore:**
 - [x] In the General tab, create a backup of the settings.
 - [x] Change some settings in some PowerToys.
 - [x] Restore the settings in the General tab and verify the Settings you've applied were reset.

## FancyZones Editor

- [x] Open editor from the settings
- [x] Open editor with a shortcut
- [x] Create a new layout (grid and canvas)
- [x] Duplicate a template and a custom layout
- [x] Delete layout
- [x] Edit templates (number of zones, spacing, distance to highlight adjacent zones). Verify after reopening the editor that saved settings are kept the same.
- [x] Edit canvas layout: zones size and position, create or delete zones.
- [x] Edit grid layout: split, merge, resize zones.
- [x] Check `Save and apply` and `Cancel` buttons behavior after editing.
- [x] Assign a layout to each monitor.
- [x] Assign keys to quickly switch layouts (custom layouts only), `Win + Ctrl + Alt + number`.
- [x] Assign horizontal and vertical default layouts
- [x] Test duplicate layout focus
   * Select any layout X in 'Templates' or 'Custom' section by click left mouse button
   * Mouse right button click on any layout Y in 'Templates' or 'Custom' sections
   * Duplicate it by clicking 'Create custom layout' (Templates section) or 'Duplicate' in 'Custom' section
   * Expect the layout Y is duplicated

## FancyZones

### Appearance
- [x] Change colors, opacity and `Show zone number` options. Verify they're applied.

### Excluded apps
- [x] Exclude some apps, verify that they're not applicable to a zone.

### Dragging
- [x] `Hold Shift key to activate zones while dragging` on, `Use a non-primary mouse button to toggle zone activation` off. Start dragging a window, then press shift. Zones are shown when dragging a window with shift pressed, hidden when you released shift or snapped zone.
- [x] `Hold Shift key to activate zones while dragging` on, `Use a non-primary mouse button to toggle zone activation` off. Press shift first, then start dragging a window. Zones are shown when dragging a window with shift pressed, hidden when you released shift or snapped zone.
- [x]  `Hold Shift key to activate zones while dragging` off, `Use a non-primary mouse button to toggle zone activation` on. Zones are shown immediately when dragging a window and hidden when you click a non-primary mouse button or press shift.
- [x] `Hold Shift key to activate zones while dragging` off, `Use a non-primary mouse button to toggle zone activation` off. Zones are shown immediately when dragging a window, hidden when you press shift.
- [x] `Hold Shift key to activate zones while dragging` on, `Use a non-primary mouse button to toggle zone activation` on. Zones aren't shown immediately, only when shift is pressed or when a non-primary mouse click changes the state.  
- [x] `Show zones on all monitor whilw dragging a window` - turn on,off, verify behavior.
- [x] Create a canvas layout with overlapping zones, check zone activation behavior with all `When multiple zones overlap` options
- [x] `Make dragged window transparent` - turn on, off, verify behavior

### Snapping
Disable FZ and clear `app-zone-history.json` before starting. FancyZones should be disabled, otherwise, it'll save cashed values back to the file.

- [x] Snap a window to a zone by dragging, verify `app-zone-history.json` contains info about the window position on the corresponding work area.
- [x] Snap a window to a zone by a keyboard shortcut, verify `app-zone-history.json` contains info about the window position on the corresponding work area.
- [x] Snap a window to another monitor, verify `app-zone-history.json` contains positions about zones on both monitors.
- [x] Snap a window to several zones, verify zone numbers in the json file are correct.
- [x] Snap a window to a zone, unsnap it, verify this app was removed from the json file.
- [x] Snap the same window to a zone on two different monitors or virtual desktops. Then unsnap from one of them, verify that info about unsnapped zone was removed from `app-zone-history.json`. Verify info about the second monitor/virtual desktop is kept.  
- [x] Enable `Restore the original size of windows when unsnapping`, snap window, unsnap window, verify the window changed its size to original.
- [x] Disable `Restore the original size of windows when unsnapping`, snap window, unsnap window, verify window size wasn't changed.
- [x] Disable `Restore the original size of windows when unsnapping`, snap window, enable `Restore the original size of windows when unsnapping`, unsnap window, verify window size wasn't changed. 
- [x] Launch PT in user mode, try to assign a window with administrator privileges to a zone. Verify the notification is shown.
- [x] Launch PT in administrator mode, assign a window with administrator privileges.
* Open `Task view` , right-click on the window, check the `Show this window on all desktops` or the `Show windows from this app on all desktops` option to turn it on.
    - [x] Turn Show this window on all desktops on, verify you can snap this window to a zone.
    - [x] Turn Show windows from this app on all desktops on, verify you can snap this window to a zone.

### Snapped window behavior
- [x] `Keep windows in their zones when the screen resolution changes` on, snap a window to a zone, change the screen resolution or scaling, verify window changed its size and position.
- [x] `Keep windows in their zones when the screen resolution changes` on, snap a window to a zone on the secondary monitor. Disconnect the secondary monitor (the window will be moved to the primary monitor). Reconnect the secondary monitor. Verify the window returned to its zone. 
- [x] `Keep windows in their zones when the screen resolution changes` off, snap a window to a zone, change the screen resolution or scaling, verify window didn't change its size and position.

Enable `During zone layout changes, windows assigned to a zone will match new size/positions` and prepare layouts with 1 and 3 zones where zone size/positions are different.
- [x] Snap a window to zone 1, change the layout, verify window changed its size/position.
- [x] Snap a window to zone 3, change the layout, verify window didn't change its size/position because another layout doesn't have a zone with this zone number.
- [x] Snap a window to zones 1-2, change the layout, verify window changed its size/position to fit zone 1.
- [x] Snap a window to zones 1-2, change the layout (the window will be snapped to zone 1), then return back to the previous layout, verify the window snapped to 1-2 zones.
- [x] Disable `During zone layout changes, windows assigned to a zone will match new size/positions`, snap window to zone 1, change layout, verify window didn't change its size/position

Enable `Move newly created windows to their last known zone`.
- [x] Snap a window to the primary monitor, close and reopen the window. Verify it's snapped to its zone.
- [x] Snap a window to zones on the primary and secondary monitors. Close and reopen the app. Verify it's snapped to the zone on the active monitor.
- [x] Snap a window to the secondary monitor (use a different app or unsnap the window from the zone on the primary monitor), close and reopen the window. Verify it's snapped to its zone. 
- [x] Snap a window, turn off FancyZones, move that window, turn FZ on. Verify window returned to its zone.
- [x] Move unsnapped window to a secondary monitor, switch virtual desktop and return back. Verify window didn't change its position and size.
- [x] Snap a window, then resize it (it's still snapped, but doesn't fit the zone). Switch the virtual desktop and return back, verify window didn't change its size.

Enable `Move newly created windows to the current active monitor`.
- [x] Open a window that wasn't snapped anywhere, verify it's opened on the active monitor.
- [x] Open a window that was snapped on the current virtual desktop and current monitor, verify it's opened in its zone.
- [x] Open a window that was snappen on the current virtual desktop and another monitor, verify it's opened on the active monitor.
- [x] Open a window that was snapped on another virtual desktop, verify it's opened on the active monitor.

- [x] Enable `Allow popup windows snapping` and `Allow child windows snapping`, try to snap Notepad++ search window. Verify it can be snapped.
- [x] Enable `Allow popup windows snapping`, snap Teams, verify a popup window appears in its usual position.
- [x] Enable `Allow popup windows snapping`, snap Visual Studio Code to a zone, and open any menu. Verify the menu is where it's supposed to be and not on the top left corner of the zone.
- [x] Enable `Allow child windows snapping`, drag any child window (e.g. Solution Explorer), verify it can be snapped to a zone.
- [x] Disable `Allow child windows snapping`, drag any child window (e.g. Solution Explorer), verify it can't be snapped to a zone.

### Switch between windows in the current zone
Enable `Switch between windows in the current zone` (default shortcut is `Win + PgUp/PgDown`)
- [x] Snap several windows to one zone, verify switching works.
- [x] Snap several windows to one zone, switch virtual desktop, return back, verify window switching works.
- [x] Disable `Switch between windows in the current zone`, verify switching doesn't work.
  
### Override Windows Snap
- [x] Disable `Override Windows Snap`, verify it's disabled.

Enable `Override Windows Snap`.
Select Move windows based on `Zone index`.
- [x] Open the previously not snapped window, press `Win`+`LeftArrow` / `Win`+`RightArrow`, verify it's snapped to a first/last zone.
- [x] Verify `Win`+`LeftArrow` moves the window to a zone with the previous index.
- [x] Verify `Win`+`RightArrow` moves the window to a zone with the next index.
- [x] Verify `Win`+`ArrowUp` and `Win`+`ArrowDown` work as usual.

- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`LeftArrow` doesn't move the window to any zone when the window is in the first zone.
- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`RightArrow` doesn't move the window to any zone when the window is in the last zone.

One monitor:
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`LeftArrow` doesn't move the window to any zone when the window is in the first zone.
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`RightArrow` doesn't move the window to any zone when the window is in the last zone.

Two and more monitors:
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`LeftArrow` cycles window position moving it from the first zone on the current monitor to the last zone of the left (or rightmost, if the current monitor is leftmost) monitor.
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`RightArrow` cycles window position moving it from the last zone on the current monitor to the first zone of the right (or leftmost, if the current monitor is rightmost) monitor.

Select Move windows based on `Relative position`.
- [x] Open the previously not snapped window, press `Win`+`Arrow`, verify it's snapped.
- [x] Extend the window using `Ctrl`+`Alt`+`Win`+`Arrow`. Verify the window is snapped to all zones.
- [x] Extend the window using `Ctrl`+`Alt`+`Win`+`Arrow` and return it back using the opposite arrow. Verify it could be reverted while you hold `Ctrl`+`Alt`+`Win`.

- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`LeftArrow` cycles the window position to the left (from the leftmost zone moves to the rightmost in the same row) within one monitor.
- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`RightArrow` cycles the window position to the right within one monitor.
- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`UpArrow` cycles the window position up within one monitor.
- [x] `Move windows between zones across all monitors` disabled. Verify `Win`+`DownArrow` cycles the window position down within one monitor.

- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`LeftArrow` cycles the window position to the left (from the leftmost zone moves to the rightmost in the same row) within all monitors.
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`RightArrow` cycles the window position to the right within all monitors.
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`UpArrow` cycles the window position up within all monitors.
- [x] `Move windows between zones across all monitors` enabled. Verify `Win`+`DownArrow` cycles the window position down within all monitors.

### Layout apply
Enable `Enable quick layout switch`, assign numbers to custom layouts.
- [x] Switch with `Win` + `Ctrl` + `Alt` + `key`.
- [x] Switch with just a key while dragging a window.
- [x] Turn `Flash zones when switching layout` on/off, verify it's flashing/not flashing after pressing the shortcut.
- [x] Disable `Enable quick layout switch`, verify shortcuts don't work.
- [x] Disable spacing on any grid layout, verify that there is no space between zones while dragging a window.
- [x] Create a new virtual desktop, verify that there are the same layouts as applied to the previous virtual desktop.
- [x] After creating a virtual desktop apply another layout or edit the applied one. Verify that the other virtual desktop layout wasn't changed.
- [x] Delete an applied custom layout in the Editor, verify that there is no layout applied instead of it.
- [x] Apply a grid layout, change the screen resolution or scaling, verify that the assigned layout fits the screen. NOTE: canvas layout could not fit the screen if it was created on a monitor with a different resolution.

### Layout reset
* Test layout resetting.
Before testing 
   * Remove all virtual desktops 
   * Remove `CurrentVirtualDesktop` from `\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\SessionInfo\1\VirtualDesktops` 
   * Remove `VirtualDesktopIDs` from `\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VirtualDesktops`

- [x] Test screen locking
   * Set custom layouts on each monitor
   * Lock screen / unplug monitor / plug monitor
   * Verify that layouts weren't reset to defaults
   
- [x] Test restart
   * Set custom layouts on each monitor
   * Restart the computer
   * Verify that layouts weren't reset to defaults

- [x] Test applying default layouts on reset
   * Set default horizontal and vertical layouts
   * Delete `applied-layouts.json`
   * Verify that selected default layout is applied according to configuration

### Span zones across monitors
- [x] Switch between `Allow zones to span across monitors` on and off. Verify that layouts are applied correctly in both cases.

Repeat the previous subsections steps after enabling `Allow zones to span across monitors`
- [x] Dragging
- [x] Snapping
- [x] Snapped window behavior
- [x] Switch between windows in the current zone
- [x] Override Windows Snap
- [x] Layout apply
- [x] Layout reset

## Awake
 - [x] Try out the features and see if they work, no list at this time.

## Crop And Lock
 * Thumbnail mode
   - [x] Test with win32 app
   - [x] Test with packaged app
   
 * Reparent mode (there are known issues where reparent mode doesn't work for some apps)
   - [x] Test with win32 app
   - [x] Test with packaged app

## DSC
 * You need to have some prerequisites installed:
   - PowerShell >= 7.2 .
   - PSDesiredStateConfiguration 2.0.7 or higher `Install-Module -Name PSDesiredStateConfiguration`.
   - WinGet [version v1.6.2631 or later](https://github.com/microsoft/winget-cli/releases). (You'll likely have this one already)
 * Open a PowerShell 7 instance and navigate to the sample scripts from PowerToys (`src/dsc/Microsoft.PowerToys.Configure/examples/`).
   - [x] Run `winget configure .\disableAllModules.dsc.yaml`. Open PowerToys Settings and verify all modules are disabled.
   - [x] Run `winget configure .\enableAllModules.dsc.yaml`. Open PowerToys Settings and verify all modules are enabled.
   - [x] Run `winget configure .\configureLauncherPlugins.dsc.yaml`. Open PowerToys Settings and verify all PowerToys Run plugins are enabled, and the Program plugin is not global and its Activation Keyword has changed to "P:".
   - [x] Run `winget configure .\configuration.dsc.yaml`. Open PowerToys Settings the Settings have been applied. File Locksmith is disabled. Shortcut Guide is disabled with an overlay opacity set to 50. FancyZones is enabled with the Editor hotkey set to "Shift+Ctrl+Alt+F".
   - [x] If you run a winget configure command above and PowerToys is running, it will eventually close and automatically reopen after the configuration process is done.
   - [x] If you run a winget configure command above and PowerToys is not running, it won't automatically reopen after the configuration process is done.

## Quick Accent
 * Enable Quick Accent and open notepad. Then:
   - [x] Press `a` and the left or right arrow and verify the accent menu appears and adds the accented letter you've selected. Use left and arrow keys to cycle through the options.
   - [x] Press `a` and the space key and verify the accent menu appears and adds the accented letter you've selected. Use <kbd>Space</kbd> to navigate forward, <kbd>Space</kbd> + <kbd>Shift</kbd> to navigate backward.
   - [x] Disable Quick Accent and verify you can no longer add accented characters through Quick Accent.
 * Test the different settings and verify they are applied:
   - [x] Activation key
   - [x] Language (for example, Currency has no accents for 'a' but has for 's')
   - [x] Toolbar position (test every option, some had issues before)
   - [x] Input delay
   - [x] Exclude some apps. Verify that Quick Accent is not activated for them.
   - [x] Sort characters by frequency.
   - [x] Always start on the first character when using left/right arrows as activation method.

## Advanced Paste
  NOTES:
    When using Advanced Paste, make sure that window focused while starting/using Advanced paste is text editor or has text input field focused (e.g. Word).
 * Paste As Plain Text
   - [x] Copy some rich text (e.g word of the text is different color, another work is bold, underlined, etd.).
   - [x] Paste the text using standard Windows Ctrl + V shortcut and ensure that rich text is pasted (with all colors, formatting, etc.)
   - [x] Paste the text using Paste As Plain Text activation shortcut and ensure that plain text without any formatting is pasted.
   - [x] Paste again the text using standard Windows Ctrl + V shortcut and ensure the text is now pasted plain without formatting as well.
   - [x] Copy some rich text again.
   - [ ] Open Advanced Paste window using hotkey, click Paste as Plain Text button and confirm that plain text without any formatting is pasted.
   - [x] Copy some rich text again.
   - [ ] Open Advanced Paste window using hotkey, press Ctrl + 1 and confirm that plain text without any formatting is pasted.
 * Paste As Markdown
   - [x] Open Settings and set Paste as Markdown directly hotkey
   - [x] Copy some text (e.g. some HTML text - convertible to Markdown)
   - [x] Paste the text using set hotkey and confirm that pasted text is converted to markdown
   - [x] Copy some text (same as in the previous step or different. If nothing is coppied between steps, previously pasted Markdown text will be picked up from clipboard and converted again to nested Markdown).
   - [x] Open Advanced Paste window using hotkey, click Paste as markdown button and confirm that pasted text is converted to markdown
   - [x] Copy some text (same as in the previous step or different. If nothing is coppied between steps, previously pasted Markdown text will be picked up from clipboard and converted again to nested Markdown).
   - [x] Open Advanced Paste window using hotkey, press Ctrl + 2 and confirm that pasted text is converted to markdown
 * Paste As JSON
   - [x] Open Settings and set Paste as JSON directly hotkey
   - [x] Copy some XML or CSV text (or any other text, it will be converted to simple JSON object)
   - [x] Paste the text using set hotkey and confirm that pasted text is converted to JSON
   - [x] Copy some text (same as in the previous step or different. If nothing is coppied between steps, previously pasted JSON text will be picked up from clipboard and converted again to nested JSON).
   - [x] Open Advanced Paste window using hotkey, click Paste as markdown button and confirm that pasted text is converted to markdown
   - [x] Copy some text (same as in the previous step or different. If nothing is coppied between steps, previously pasted JSON text will be picked up from clipboard and converted again to nested JSON).
   - [x] Open Advanced Paste window using hotkey, press Ctrl + 3 and confirm that pasted text is converted to markdown
 * Paste as custom format using AI
   - [x] Open Settings, navigate to Enable Paste with AI and set OpenAI key.
   - [x] Copy some text to clipboard. Any text.
   - [ ] Open Advanced Paste window using hotkey, and confirm that Custom intput text box is now enabled. Write "Insert smiley after every word" and press Enter. Observe that result preview shows coppied text with smileys between words. Press Enter to paste the result and observe that it is pasted.
   - [ ] Open Advanced Paste window using hotkey. Input some query (any, feel free to play around) and press Enter. When result is shown, click regenerate button, to see if new result is generated. Select one of the results and paste. Observe that correct result is pasted.
   - [x] Open Settings and disable Custom format preview. Open Advanced Paste window with hotkey, enter some query and press enter. Observe that result is now pasted right away, without showing the preview first.
   - [x] Open Settings and Disable Enable Paste with AI. Open Advanced Paste window with hotkey and observe that Custom Input text box is now disabled.
 * Clipboard History
   - [x] Open Settings and Enable clipboard history (if not enabled already). Open Advanced Paste window with hotkey, click Clipboard history and try deleting some entry. Check OS clipboard history (Win+V), and confirm that the same entry no longer exist.
   - [x] Open Advanced Paste window with hotkey, click Clipboard history, and click any entry (but first). Observe that entry is put on top of clipboard history. Check OS clipboard history (Win+V), and confirm that the same entry is on top of the clipboard.
   - [x] Open Settings and Disable clipboard history. Open Advanced Paste window with hotkey and observe that Clipboard history button is disabled.
 * Disable Advanced Paste, try different Advanced Paste hotkeys and confirm that it's disabled and nothing happens.