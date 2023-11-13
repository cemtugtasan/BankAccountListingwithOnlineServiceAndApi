namespace BankAccountProject.Entities
{
    public class BankAccount
    {
        public int id { get; set; }
        public string hesap_kodu { get; set; }
        public string hesap_adi { get; set; }
        public string tipi { get; set; }
        public int ust_hesap_id { get; set; }
        public decimal? borc { get; set; }
        public decimal? alacak { get; set; }
        public decimal? borc_sistem { get; set; }
        public decimal? alacak_sistem { get; set; }
        public decimal? borc_doviz { get; set; }
        public decimal? alacak_doviz { get; set; }
        public decimal? borc_islem_doviz { get; set; }
        public decimal? alacak_islem_doviz { get; set; }
        public string? birim_adi { get; set; }
        public int bakiye_sekli { get; set; }
        public int aktif { get; set; }
        public int dovizkod { get; set; }
    }
}
