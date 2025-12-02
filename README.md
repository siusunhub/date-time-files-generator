### Example use case: backup job marker

One practical way to use this tool is as a **backup marker**:

1. Add your backup destination folder (for example `D:\Backups\MyServer`) to the `path` collection.
2. Schedule `DateTimeFiles.exe` to run **right after** your backup job finishes.
3. After each run, the tool will create a file like:

   ```text
   D:\Backups\MyServer\_2025-12-03.txt

## Executables

### DateTimeFilesSetting.exe

A small Windows configuration tool used to **manage the folders** where date files will be generated.

- Run this program first.
- Add, edit or remove the folder paths where you want the `_YYYY-MM-DD.txt` files to appear.
- These paths are saved into the shared database and are used later by `DateTimeFiles.exe`.

### DateTimeFiles.exe

The main console tool that **creates the date files**.

- When you run it, it reads all configured paths and generates a date file (for example `_2025-12-03.txt`) in each folder.
- On the next run, it deletes the previous date file and creates a new one for the current day.
- Typically you set this executable to run automatically using **Windows Task Scheduler**:
  - Either once per day (to mark the current date in your folders), or  
  - Right after your backup job finishes, so the file date shows the **last backup time**.
