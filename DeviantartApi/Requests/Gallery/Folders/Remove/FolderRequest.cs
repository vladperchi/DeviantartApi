﻿namespace DeviantartApi.Requests.Gallery.Folders.Remove
{
    public class FolderRequest : Collections.Folders.Remove.FolderRequest
    {
        protected override string FolderPath { get; set; } = "gallery";

        public FolderRequest(string folderId) : base(folderId)
        {
        }
    }
}
