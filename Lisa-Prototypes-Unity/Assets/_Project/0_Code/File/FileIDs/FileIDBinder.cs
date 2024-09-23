using System.Collections.Generic;

public static class FileIDBinder {
    public static readonly Dictionary<FileID, FileSettings> FileConfigIDs = new();

    public static FileID Bind(FileSettings file) {
        FileID newID = new(FileConfigIDs.Count);
        FileConfigIDs.Add(newID, file);
        return newID;
    }

    public static FileSettings GetTile(FileID ID) {
        if (FileConfigIDs.TryGetValue(ID, out FileSettings file)) {
            return file;
        }
        throw new System.Exception("File could not be extracted from dictionary.");
    }
}

