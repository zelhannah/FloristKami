using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FloristKami.Models;

namespace FloristKami.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = GetProducts();
        return View(products);
    }

    public IActionResult Favorites()
    {
        var products = GetProducts();
        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<Product> GetProducts()
    {
        return new List<Product>
            {
                // Bouquet, Harga 150.000
                new Product
                {
                    Id = 1,
                    Name = "Aster Pikok Bouquet",
                    Category = "bouquet",
                    Image = "/img/1. Aster.png",
                    Rating = 4.8,
                    Description = "Bunga Aster dan Daun Pikok",
                    PriceMin = 150000,
                    PriceMax = 170000
                },
                new Product
            {
                Id = 2,
                Name = "Mini White Rose Bouquet",
                Category = "bouquet",
                Image = "/img/1. MiniWhiteRose.png",
                Rating = 4.9,
                Description = "3 tangkai mawar putih segar dengan bunga pikok",
                PriceMin = 150000,
                PriceMax = 170000
            },
            new Product
            {
                Id = 3,
                Name = "Mini Red Rose Bouquet",
                Category = "bouquet",
                Image = "/img/.png",
                Rating = 5.0,
                Description = "3 tangkai mawar merah segar dengan bunga pikok",
                PriceMin = 150000,
                PriceMax = 170000
            },
            new Product
            {
                Id = 4,
                Name = "Mini Pink Rose Bouquet",
                Category = "bouquet",
                Image = "/img/.png",
                Rating = 5.0,
                Description = "3 tangkai mawar merah muda segar dengan bunga pikok",
                PriceMin = 150000,
                PriceMax = 170000
            },
            //Harga 200.000
            new Product
            {
                Id = 5,
                Name = "Mix Mawar with Aster Bouquet",
                Category = "bouquet",
                Image = "/img/2. MixRoseAster.png",
                Rating = 4.7,
                Description = "Rangkaian tiga tangkai mawar segar dipadukan dengan aster dan daun pikok",
                PriceMin = 200000,
                PriceMax = 250000
            },
            new Product
            {
                Id = 6,
                Name = "Red Rose Bouquet",
                Category = "bouquet",
                Image = "/img/2. MiniRedRose.png",
                Rating = 5.0,
                Description = "5 tangkai mawar merah segar dengan daun pikok",
                PriceMin = 200000,
                PriceMax = 250000
            },
            new Product
            {
                Id = 7,
                Name = "Soft Pink Rose Bouquet",
                Category = "bouquet",
                Image = "/img/2. MedPinkRose.jpg",
                Rating = 5.0,
                Description = "5 tangkai mawar merah muda segar dengan daun pikok",
                PriceMin = 200000,
                PriceMax = 250000
            },
            new Product
            {
                Id = 8,
                Name = "Pink Rose Bouquet",
                Category = "bouquet",
                Image = "/img/2. MedPinkRoses.jpg",
                Rating = 5.0,
                Description = "5 tangkai mawar merah muda segar dengan daun pikok",
                PriceMin = 200000,
                PriceMax = 250000
            },
            new Product
            {
                Id = 9,
                Name = "Mix Mawar with Aster Bouquet",
                Category = "bouquet",
                Image = "/img/2. MixRoseAster3.png",
                Rating = 4.7,
                Description = "Rangkaian tiga tangkai mawar segar dipadukan dengan aster",
                PriceMin = 200000,
                PriceMax = 250000
            },
            new Product
            {
                Id = 10,
                Name = "Pink Rose Peacock Bouquet",
                Category = "bouquet",
                Image = "/img/2. PinkRosePikok.png",
                Rating = 4.9,
                Description = "Rangkaian mawar merah muda dengan bunga peacock segar ukuran sedang",
                PriceMin = 200000,
                PriceMax = 250000
            },
            // Harga 250.000
            new Product
            {
                Id = 11,
                Name = "Medium Mix Aster Roses Bouquet",
                Category = "bouquet",
                Image = "/img/2.5 MixAster.png",
                Rating = 4.8,
                Description = "Rangkaian 4 tangkai mawar merah dipadukan aster dan daun pikok",
                PriceMin = 250000,
                PriceMax = 300000
            },
            new Product
            {
                Id = 12,
                Name = "Medium Mix Roses Bouquet",
                Category = "bouquet",
                Image = "/img/2.5 Mix.png",
                Rating = 4.9,
                Description = " ",
                PriceMin = 250000,
                PriceMax = 300000
            },
            new Product
            {
                Id = 13,
                Name = "Medium Roses",
                Category = "bouquet",
                Image = "/img/2.5 Rose.png",
                Rating = 4.7,
                Description = " ",
                PriceMin = 250000,
                PriceMax = 300000
            },
            new Product
            {
                Id = 14,
                Name = "Medium White Roses",
                Category = "bouquet",
                Image = "/img/2.5 WhiteRose.png",
                Rating = 4.8,
                Description = "Mawar Putih",
                PriceMin = 250000,
                PriceMax = 300000
            },
            //Harga 300.000
            // belum lengkap

            // ===== SPECIAL EDITION COLLECTION =====
            new Product
            {
                Id = 30,
                Name = "Artificial Flower Vase",
                Category = "custom",
                Image = "/img/.png",
                Rating = 4.9,
                Description = "Request/Custom Edition",
                PriceMin = 150000,
                PriceMax = 500000
            },
            new Product
            {
                Id = 31,
                Name = "Mini Bloom Box",
                Category = "specialedition",
                Image = "/img/MiniBloom.PNG",
                Rating = 4.8,
                Description = "Bloom Box ukuran kecil",
                PriceMin = 350000,
                PriceMax = 400000
            },
            new Product
            {
                Id = 32,
                Name = "Bloom Box",
                Category = "specialedition",
                Image = "/img/BloomBox.PNG",
                Rating = 4.7,
                Description = "Bloom box all flowers",
                PriceMin = 400000,
                PriceMax = 600000
            },
            new Product
            {
                Id = 33,
                Name = "Big Bloom Box",
                Category = "specialedition",
                Image = "/img/BigBloom.PNG",
                Rating = 4.7,
                Description = "Bloom box all flowers",
                PriceMin = 650000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 33,
                Name = "Bloom box with acrylic",
                Category = "specialedition",
                Image = "/img/BloomAcrylic.PNG",
                Rating = 5.0,
                Description = "Bloom box pakai acrylic",
                PriceMin = 600000,
                PriceMax = 700000
            },
            new Product
            {
                Id = 34,
                Name = "Baloon Box",
                Category = "specialedition",
                Image = "/img/BalonBox.PNG",
                Rating = 4.6,
                Description = "..",
                PriceMin = 350000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 35,
                Name = "Acrylic Standing Board",
                Category = "specialedition",
                Image = "/img/AcrylicStanding.png",
                Rating = 5.0,
                Description = "Tinggi 1,2m. Ukuran board 40x60cm. Warna acrylic custom",
                PriceMin = 800000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 36,
                Name = "Paper Flower Board",
                Category = "specialedition",
                Image = "/img/PaperFlower (1).png",
                Rating = 5.0,
                Description = "Ukuran 80x60cm. Pemesanan minimal h-3 hari",
                PriceMin = 800000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 37,
                Name = "Money Flower Box",
                Category = "specialedition",
                Image = "/img/MoneyBox.PNG",
                Rating = 5.0,
                Description = "Harga termasuk jumlah uang yang dipakai. Pre-order 7 hari",
                PriceMin = 300000,
                PriceMax = 1500000
            },
            new Product
            {
                Id = 38,
                Name = "Wedding Bouquet",
                Category = "specialedition, custom",
                Image = "/img/.png",
                Rating = 5.0,
                Description = "Custom flowers. Pre-order 7 hari",
                PriceMin = 450000,
                PriceMax = 1000000
            },
            
            // ===== KRANS COLLECTION =====
            new Product
            {
                Id = 39,
                Name = "Custom Krans Flower",
                Category = "custom",
                Image = "/img/KransCustom.PNG",
                Rating = 4.8,
                Description = "Karangan bunga duka cita dengan bunga putih, menyampaikan belasungkawa dengan hormat",
                PriceMin = 750000,
                PriceMax = 1000000
            },new Product
            {
                Id = 40,
                Name = "Krans Flower",
                Category = "krans",
                Image = "/img/Krans800.PNG",
                Rating = 4.8,
                Description = "Karangan bunga duka cita dengan bunga putih, menyampaikan belasungkawa dengan hormat",
                PriceMin = 800000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 41,
                Name = "Krans Flower",
                Category = "krans",
                Image = "/img/Krans900.PNG",
                Rating = 4.8,
                Description = "Karangan bunga duka cita dengan bunga putih, menyampaikan belasungkawa dengan hormat",
                PriceMin = 900000,
                PriceMax = 1000000
            },

            // ===== STANDING FLOWER =====
            new Product
            {
                Id = 42,
                Name = "Simple Standing",
                Category = "standing",
                Image = "/img/Standing750.PNG",
                Rating = 4.9,
                Description = "Standing flower simple dengan sterofoam custom judul",
                PriceMin = 750000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 43,
                Name = "Congratulations Standing",
                Category = "standing",
                Image = "/img/Standing900.PNG",
                Rating = 4.9,
                Description = "Standing flower mix bunga mawar dengan kain pita",
                PriceMin = 900000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 44,
                Name = "Standing Deluxe",
                Category = "standing",
                Image = "/img/Standing110.PNG",
                Rating = 4.9,
                Description = "Standing flower mewah dengan bunga mix beserta ucapan dan pita",
                PriceMin = 1100000,
                PriceMax = 1300000
            },
            new Product
            {
                Id = 45,
                Name = "Double Standing Deluxe",
                Category = "standing",
                Image = "/img/standing-congrats.jpg",
                Rating = 5.0,
                Description = "Double Standing flower mewah dengan bunga mix segar",
                PriceMin = 1300000,
                PriceMax = 2000000
            },

            // ===== FLOWER BOARD =====
            new Product
            {
                Id = 46,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/Board600 (1).PNG",
                Rating = 4.9,
                Description = "Ukuran 1,25 Meter x 2 Meter, Hiasan diatas",
                PriceMin = 600000,
                PriceMax = 700000
            },
            new Product
            {
                Id = 47,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/Board700 (1).PNG",
                Rating = 4.7,
                Description = "Ukuran 1,25 Meter x 2 Meter, Hiasan diatas dan bawah",
                PriceMin = 700000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 48,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/Board850.PNG",
                Rating = 4.7,
                Description = "Ukuran 1,25 Meter x 2 Meter, Full bunga",
                PriceMin = 850000,
                PriceMax = 900000
            },
            new Product
            {
                Id = 49,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/Board800 (1).PNG",
                Rating = 4.7,
                Description = "Ukuran 1,5 Meter x 2 Meter, Hiasan diatas dan bawah",
                PriceMin = 800000,
                PriceMax = 900000
            },
            new Product
            {
                Id = 50,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/Board900 (1).PNG",
                Rating = 4.7,
                Description = "Ukuran 1,5 Meter x 2 Meter, Full bunga",
                PriceMin = 900000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 51,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/1100.png",
                Rating = 4.7,
                Description = "Ukuran 1,5 Meter x 1 Meter, Full mix bunga",
                PriceMin = 1100000,
                PriceMax = 1300000
            },
            new Product
            {
                Id = 52,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/1400.png",
                Rating = 4.6,
                Description = "Ukuran 1,5 Meter x 2 Meter, Full bunga border",
                PriceMin = 1400000,
                PriceMax = 1500000
            },
            new Product
            {
                Id = 53,
                Name = "Flowers Board",
                Category = "board",
                Image = "/img/1500.png",
                Rating = 4.6,
                Description = "Ukuran 1,5 Meter x 4 Meter, Hiasan atas bawah",
                PriceMin = 1500000,
                PriceMax = 2000000
            },

            // ===== VASE ARRANGEMENT =====
            new Product
            {
                Id = 54,
                Name = "Basket Table Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Mix flower Aster dengan Mawar",
                PriceMin = 300000,
                PriceMax = 350000
            },
            new Product
            {
                Id = 55,
                Name = "Basket Gift Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Karangan bunga ukuran besar dengan ucapan",
                PriceMin = 350000,
                PriceMax = 450000
            },
            new Product
            {
                Id = 56,
                Name = "White Table Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Vas bunga mawar putih dengan keramik",
                PriceMin = 450000,
                PriceMax = 500000
            },
            new Product
            {
                Id = 57,
                Name = "Red Rose Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Karagan bunga pot mawar merah",
                PriceMin = 450000,
                PriceMax = 500000
            },
            new Product
            {
                Id = 58,
                Name = "Pinkeu Table Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Bunga pot mawar pink dengan lily besar",
                PriceMin = 650000,
                PriceMax = 700000
            },
            new Product
            {
                Id = 59,
                Name = "Amazing Table Vase",
                Category = "vase",
                Image = "/img/vase-table.jpg",
                Rating = 4.7,
                Description = "Karangan bunga pot mewah dengan pilihan bunga segar",
                PriceMin = 750000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 60,
                Name = "Premium Rose Vase Collection",
                Category = "vase",
                Image = "/img/vase-premium.jpg",
                Rating = 4.8,
                Description = "Koleksi bunga mawar premium dalam vas mewah",
                PriceMin = 800000,
                PriceMax = 1000000
            },
            //Anggrek
            new Product
            {
                Id = 61,
                Name = "Orchid Custom Vase",
                Category = "custom",
                Image = "/img/OrchidCustom (1).PNG",
                Rating = 4.7,
                Description = "Rangkai bunga anggrek impianmu sendiri",
                PriceMin = 500000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 62,
                Name = "Pure White Orchid",
                Category = "vase",
                Image = "/img/Orchid650.PNG",
                Rating = 4.7,
                Description = "Rangkaian bunga vas anggrek putih",
                PriceMin = 650000,
                PriceMax = 800000
            },
            new Product
            {
                Id = 63,
                Name = "Pink Orchid Vase",
                Category = "vase",
                Image = "/img/Orchid800.png",
                Rating = 4.7,
                Description = "Bunga vas anggrek pink segar imoet",
                PriceMin = 800000,
                PriceMax = 1000000
            },
            new Product
            {
                Id = 64,
                Name = "Mix Orchid Table Vase",
                Category = "vase",
                Image = "/img/Orchid1350.PNG",
                Rating = 4.7,
                Description = "Rangakaian bunga anggrek mix dalam vas",
                PriceMin = 1350000,
                PriceMax = 1500000
            },
            new Product
            {
                Id = 65,
                Name = "Premium Orchid Vase",
                Category = "vase",
                Image = "/img/Orchid1950",
                Rating = 4.7,
                Description = "Rangkaian bunga pot anggrek mewah",
                PriceMin = 1950000,
                PriceMax = 2500000
            },
        };
    }
}


/*
PENJELASAN CONTROLLER:
=======================
1. Index() - Menampilkan katalog lengkap produk di halaman utama
2. Favorites() - Menampilkan halaman favorit (filtering dilakukan di client-side)
3. GetProducts() - Central data source untuk semua produk
   - Dalam production, ini bisa diganti dengan database query
   - Sekarang menggunakan hardcoded data untuk development
4. Setiap produk sudah dilengkapi dengan:
   - Harga yang jelas
   - Deskripsi yang menarik dan SEO-friendly
   - Rating untuk social proof
   - Kategori untuk sistem filter
*/