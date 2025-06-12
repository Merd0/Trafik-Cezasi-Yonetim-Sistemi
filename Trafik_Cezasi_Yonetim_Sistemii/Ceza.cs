using System;

public class Ceza
{
    public string AdSoyad { get; set; }
    public string Plaka { get; set; }
    public string ID { get; set; }
    public DateTime CezaTarihi { get; set; }
    public decimal Tutar { get; set; }
    public bool OdendiMi { get; set; }
}

public class KirmiziIsikCezasi : Ceza
{
    public decimal HesaplaCezaTutari() => 250; // Örnek tutar
}

public class HizCezasi : Ceza
{
    public decimal HesaplaCezaTutari() => 200; // Örnek tutar
}

public class ParkCezasi : Ceza
{
    public decimal HesaplaCezaTutari() => 150; // Örnek tutar
}
