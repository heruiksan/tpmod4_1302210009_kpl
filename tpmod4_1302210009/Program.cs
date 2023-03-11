using System;

namespace tpmod4_1302210009
{
    class kodepos
    {
        static void Main(string[] args)
        {
            //no.1
            kodepos getkode = new kodepos();
            datakota kota = datakota.Samoja; // MEMILIH KOTA YANG INGIN DI MUNCULKAN NAMANYA
            int kode = kodepos.getkodepos(kota);//MENAMPILKAN KODEPOS SESUAI INDEX PADA ARRAY DAN ENUM (kodepos[(int)kota];)
            Console.WriteLine("Nama kota: "+kota + "\n "+"Kode Pos: "+ kode);

            //no.2
            doormachine pintu = new doormachine();
            pintu.TrigerAktif(trigger.pintuKunci);
            pintu.TrigerAktif(trigger.pintuBuka);
            pintu.TrigerAktif(trigger.pintuKunci);
            pintu.TrigerAktif(trigger.pintuBuka);
            Console.ReadKey();
        }
        static int getkodepos(datakota kota)
        {
            int[] kodepos = { 40266, 40287, 40287, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            // DAFTAR KODEPOS DIBUAT ARRAY
            return kodepos[(int)kota];
        }

    }
    enum datakota //DAFTAR NAMA KOTA DI BUAT ENUM
    {
        Batununggal,
        Kujangsari ,
        Mengger ,
        Wates ,
        Cijaura, 
        Jatisari, 
        Margasari, 
        Sekejati ,
        Kebonwaru ,
        Maleer ,
        Samoja
    }

    public enum pintu
    {
        terkunci,
        terbuka
    }
    public enum trigger
    {
        pintuBuka,
        pintuKunci
    }
    public class doormachine
    {
        public pintu currentstate = pintu.terkunci;
        public class transisi
        {
            public pintu stateAwal;
            public pintu stateAkhir;
            public trigger Trigger;
            public transisi(pintu stateAwal, pintu stateAkhir, trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                Trigger = trigger;
            }
        }
        transisi[] transisi2 =
        {
            new transisi(pintu.terkunci, pintu.terbuka, trigger.pintuBuka),
            new transisi(pintu.terbuka, pintu.terkunci, trigger.pintuKunci),
            new transisi(pintu.terbuka,pintu.terbuka, trigger.pintuBuka),
            new transisi(pintu.terkunci, pintu.terkunci, trigger.pintuKunci)
        };
        private pintu getstateselanjutnya(pintu stateAwal, trigger Trigger)
        {
            pintu stateAkhir = stateAwal;
            for(int i = 0;i< transisi2.Length;i++)
            {
                transisi perubahan = transisi2[i];
                if(stateAwal == perubahan.stateAwal && Trigger == perubahan.Trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }
        public void TrigerAktif(trigger Trigger)
        {
            currentstate = getstateselanjutnya(currentstate, Trigger);
            Console.WriteLine("State sekarang adalah "+ currentstate);
            if(currentstate == pintu.terkunci)
            {
                Console.WriteLine("Pintu sedang terkunci");
            }else if (currentstate == pintu.terbuka)
            {
                Console.WriteLine("Pintu sedang terbuka");
            }
        }
    }
    /*public static void Main(string[] args)
    {
        doormachine pintu = new doormachine();
        pintu.TrigerAktif(trigger.pintuKunci);
        pintu.TrigerAktif(trigger.pintuBuka);
        pintu.TrigerAktif(trigger.pintuKunci);
        pintu.TrigerAktif(trigger.pintuBuka);
    }*/
}