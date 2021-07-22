/****************************************************************************
**                      SAKARYA ÜNİVERSİTESİ
**            BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**              BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                NESNEYE DAYALI PROGRAMLAMA DERSİ
**                     2020-2021 BAHAR DÖNEMİ
**                       DÖNEM PROJE ÖDEVİ
**
** ÖĞRENCİ ADI............: BİLAL AÇIKGÖZ
** ÖĞRENCİ NUMARASI.......: b201200022
** DERSİN ALINDIĞI GRUP...: 1. ÖĞRETİM A GRUBU
****************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Image = Image.FromFile("Gorseller\\Ucaksavar.png");
            Left = (panelGenisligi - Width) / 2;
            HareketMesafesi = Width;    // Her bir cisim için hareket mesafesi farklı olduğu için cisim abstractın dan müdahale etmeyeceğiz.
        }

    }
}
