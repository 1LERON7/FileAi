using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAi.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UnicName { get; set; } = string.Empty;
        public double Size { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public string Path { get; set; } = string.Empty;

        public string DisplayText => $"[{Id}] {UnicName} | ({Size / 1024:F2} KB | {Type} | Uploaded: {UploadedAt})";
    }
}
