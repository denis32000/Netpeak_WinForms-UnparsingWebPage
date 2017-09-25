using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webpageParserShvetsovDenis
{
    public class ResponseModel
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ServerResponse { get; set; }
        public string ResponseTime { get; set; }

        [NotMapped]
        public List<string> HeadersH1 { get; set; }
        [NotMapped]
        public List<string> Images { get; set; }
        [NotMapped]
        public List<string> AhrefLinks { get; set; }
        
        public string HeadersH1Json { get; set; }
        public string ImagesJson { get; set; }
        public string AhrefLinksJson { get; set; }
    }
}