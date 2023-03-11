using System;

namespace tpmod4_1302210009
{
    class kodepos
    {
        static void Main(string[] args)
        {
            kodepos getkode = new kodepos();
            datakota kota = datakota.Samoja;
            int kode = kodepos.getkodepos(kota);
            Console.WriteLine(kota + " "+ kode);

            Console.ReadKey();
        }
        static int getkodepos(datakota kota)
        {
            int[] kodepos = { 40266, 40287, 40287, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            return kodepos[(int)kota];
        }

    }
    enum datakota
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
}