using System;
namespace IStockAPI.ViewModels
{
    public class CommonEntity
    {
        private DateTime CreatedTime=DateTime.Now;
        private DateTime ModifiedTime = DateTime.Now;
        public bool Is_Actv { get; set; }
        public bool Is_Del { get; set; }
        public Int64 Crtd_by { get; set; }
        public Int64 Mod_by { get; set; }


        public DateTime Crtd_ts
        {
            get
            {
                return this.CreatedTime;
            }
            set
            {
                this.CreatedTime = value;
            }
        }
        public DateTime Mod_ts
        {
            get
            {
                return this.ModifiedTime;
            }
            set
            {
                this.ModifiedTime = value;
            }
        }
        
    }
}
