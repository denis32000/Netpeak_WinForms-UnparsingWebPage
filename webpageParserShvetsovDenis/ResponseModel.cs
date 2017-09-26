using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace webpageParserShvetsovDenis
{
    public class ResponseModel : INotifyPropertyChanged
    {
        private string _link;
        private string _title;
        private string _description;
        private string _responseTime;
        private int _responseCode;
        private string _headersH1Json;
        private string _imagesJson;
        private string _ahrefLinksJson;

        public int Id { get; set; }

        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged("Link");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string ResponseTime
        {
            get { return _responseTime; }
            set
            {
                _responseTime = value;
                OnPropertyChanged("ResponseTime");
            }
        }

        public int ResponseCode
        {
            get { return _responseCode; }
            set
            {
                _responseCode = value;
                OnPropertyChanged("ResponseCode");
            }
        }

        [NotMapped]
        public List<string> HeadersH1 { get; set; }
        [NotMapped]
        public List<string> Images { get; set; }
        [NotMapped]
        public List<string> AhrefLinks { get; set; }
        
        public string HeadersH1Json
        {
            get { return _headersH1Json; }
            set
            {
                _headersH1Json = value;
                OnPropertyChanged("HeadersH1Json");
            }
        }

        public string ImagesJson
        {
            get { return _imagesJson; }
            set
            {
                _imagesJson = value;
                OnPropertyChanged("ImagesJson");
            }
        }

        public string AhrefLinksJson
        {
            get { return _ahrefLinksJson; }
            set
            {
                _ahrefLinksJson = value;
                OnPropertyChanged("AhrefLinksJson");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}