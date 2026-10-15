
using System;
using System.Collections.Generic;

class Orang
{
    public string nama { get; set; }
    public int umur { get; set; }

    public Orang(string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine(nama + " sedang melakukan aktivitas.");
    }

    public virtual void InfoOrang()
    {
        Console.WriteLine("Nama: " + nama);
        Console.WriteLine("Umur: " + umur + " tahun");
    }
}

class Pasien : Orang
{
    public string keluhan { get; set; }

    public Pasien(string nama, int umur, string keluhan)
        : base(nama, umur)
    {
        this.keluhan = keluhan;
    }

    public void CekKeluhan()
    {
        Console.WriteLine(nama + " memiliki keluhan: " + keluhan);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(nama + " sedang menjalani pemeriksaan.");
    }

    public override void InfoOrang()
    {
        base.InfoOrang();
        Console.WriteLine("Keluhan: " + keluhan);
    }
}

class TenagaMedis : Orang
{
    public string spesialisasi { get; set; }

    public TenagaMedis(string nama, int umur, string spesialisasi)
        : base(nama, umur)
    {
        this.spesialisasi = spesialisasi;
    }

    public void CekSpesialis()
    {
        Console.WriteLine(nama + " memiliki spesialisasi: " + spesialisasi);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(nama + " sedang memberikan pelayanan medis.");
    }

    public override void InfoOrang()
    {
        base.InfoOrang();
        Console.WriteLine("Spesialisasi: " + spesialisasi);
    }
}

class Dokter : TenagaMedis
{
    public Dokter(string nama, int umur, string spesialisasi)
        : base(nama, umur, spesialisasi)
    {
    }

    public void Diagnosa()
    {
        Console.WriteLine("Dokter " + nama + " sedang mendiagnosis pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Dokter " + nama + " sedang memeriksa pasien.");
    }
}

class Perawat : TenagaMedis
{
    public Perawat(string nama, int umur, string spesialisasi)
        : base(nama, umur, spesialisasi)
    {
    }

    public void CekPasien()
    {
        Console.WriteLine("Perawat " + nama + " sedang mengecek kondisi pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Perawat " + nama + " sedang merawat pasien.");
    }
}

class PasienAnak : Pasien
{
    public PasienAnak(string nama, int umur, string keluhan)
        : base(nama, umur, keluhan)
    {
    }

    public void Menangis()
    {
        Console.WriteLine("Pasien anak " + nama + " sedang menangis.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Pasien anak " + nama + " sedang diperiksa.");
    }
}

class PasienDewasa : Pasien
{
    public PasienDewasa(string nama, int umur, string keluhan)
        : base(nama, umur, keluhan)
    {
    }

    public void Konsultasi()
    {
        Console.WriteLine("Pasien dewasa " + nama + " sedang berkonsultasi.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Pasien dewasa " + nama + " sedang berkonsultasi dengan dokter.");
    }
}

class RumahSakit
{
    private List<Orang> daftarOrang = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        daftarOrang.Add(orang);
        Console.WriteLine(orang.nama + " berhasil ditambahkan ke rumah sakit.");
    }

    public void DaftarOrang()
    {
        Console.WriteLine("\n===== DAFTAR ORANG DI RUMAH SAKIT =====");

        foreach (Orang orang in daftarOrang)
        {
            Console.WriteLine("-----------------------------");
            orang.InfoOrang();
            orang.Aktivitas();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RumahSakit rumahSakit = new RumahSakit();

        Dokter dokter = new Dokter("Andi", 35, "Penyakit Dalam");
        Perawat perawat = new Perawat("Siti", 28, "Keperawatan Umum");
        PasienAnak pasienAnak = new PasienAnak("Budi", 7, "Demam");
        PasienDewasa pasienDewasa = new PasienDewasa("Rina", 25, "Sakit kepala");

        rumahSakit.TambahOrang(dokter);
        rumahSakit.TambahOrang(perawat);
        rumahSakit.TambahOrang(pasienAnak);
        rumahSakit.TambahOrang(pasienDewasa);

        rumahSakit.DaftarOrang();

    }
}
