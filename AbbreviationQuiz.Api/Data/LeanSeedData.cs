using AbbreviationQuiz.Api.Models;

namespace AbbreviationQuiz.Api.Data;

public static class LeanSeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.LeanTerms.Any()) return;

        var terms = new List<LeanTerm>
        {
            new() { Term = "Kaizen", Definition = "Sürekli iyileştirme felsefesi", Category = "Felsefe" },
            new() { Term = "Kanban", Definition = "Görsel iş akışını yöneten kart/sinyal sistemi", Category = "Sistem" },
            new() { Term = "Muda", Definition = "Değer katmayan her türlü israf", Category = "İsraf" },
            new() { Term = "Muri", Definition = "Çalışan veya ekipmanın aşırı yüklenmesi", Category = "İsraf" },
            new() { Term = "Mura", Definition = "Üretim sürecindeki dengesizlik ve düzensizlik", Category = "İsraf" },
            new() { Term = "Poka-Yoke", Definition = "İnsan hatalarını önlemeye yönelik mekanizma", Category = "Kalite" },
            new() { Term = "Jidoka", Definition = "Hata tespit edildiğinde süreci durduran otomasyon", Category = "Kalite" },
            new() { Term = "Heijunka", Definition = "Üretim hacmini ve türünü dengeleyen planlama", Category = "Sistem" },
            new() { Term = "Gemba", Definition = "İşin fiilen yapıldığı yer, saha", Category = "Felsefe" },
            new() { Term = "Andon", Definition = "Sorun anında uyarı veren görsel/sesli sinyal sistemi", Category = "Kalite" },
            new() { Term = "Hoshin Kanri", Definition = "Şirket stratejisini tüm seviyelere yayan yönetim yaklaşımı", Category = "Strateji" },
            new() { Term = "Yokoten", Definition = "Başarılı uygulamaların yatay olarak paylaşılması", Category = "Felsefe" },
            new() { Term = "Nemawashi", Definition = "Karar öncesinde tüm paydaşlardan uzlaşı sağlama süreci", Category = "Felsefe" },
            new() { Term = "Genchi Genbutsu", Definition = "Sorunu anlamak için bizzat sahaya gitme ilkesi", Category = "Felsefe" },
            new() { Term = "Hansei", Definition = "Hataları ve eksiklikleri dürüstçe değerlendirme pratiği", Category = "Felsefe" },
            new() { Term = "Kaikaku", Definition = "Mevcut süreci köklü biçimde dönüştüren radikal iyileştirme", Category = "Felsefe" },
            new() { Term = "Obeya", Definition = "Proje ekibinin birlikte çalıştığı büyük görsel yönetim odası", Category = "Sistem" },
            new() { Term = "Shojinka", Definition = "Talep değişimine göre işgücünü esnek biçimde yeniden dağıtma", Category = "Sistem" },
            new() { Term = "5S", Definition = "Sınıfla-Sırala-Sil-Standartlaştır-Sürdür iş yeri düzeni yöntemi", Category = "Sistem" },
            new() { Term = "SMED", Definition = "Kalıp değişim süresini tek haneli dakikalara indirme tekniği", Category = "Sistem" },
            new() { Term = "VSM", Definition = "Ürün akışındaki değer yaratan ve yaratmayan adımları görselleştirme", Category = "Analiz" },
            new() { Term = "JIT", Definition = "İhtiyaç duyulduğu anda tam miktarda üretim veya teslimat", Category = "Sistem" },
            new() { Term = "OEE", Definition = "Ekipmanın kullanılabilirlik, performans ve kalite çarpımıyla hesaplanan verimliliği", Category = "Metrik" },
            new() { Term = "PDCA", Definition = "Planla-Uygula-Kontrol Et-Önlem Al iyileştirme döngüsü", Category = "Sistem" },
            new() { Term = "DMAIC", Definition = "Tanımla-Ölç-Analiz Et-İyileştir-Kontrol Et problem çözme metodolojisi", Category = "Sistem" },
            new() { Term = "Takt Time", Definition = "Müşteri talebini karşılamak için bir birimin üretilmesi gereken süre", Category = "Metrik" },
            new() { Term = "Lead Time", Definition = "Siparişin alınmasından teslimata kadar geçen toplam süre", Category = "Metrik" },
            new() { Term = "Cycle Time", Definition = "Bir operatörün aynı işi tekrarlamak için geçirdiği süre", Category = "Metrik" },
            new() { Term = "WIP", Definition = "Başlanmış ancak henüz tamamlanmamış süreçteki iş miktarı", Category = "Metrik" },
            new() { Term = "Pull System", Definition = "Gerçek müşteri talebine göre tetiklenen üretim sistemi", Category = "Sistem" },
            new() { Term = "Push System", Definition = "Talep tahminine dayanarak önceden üretip stok biriktiren sistem", Category = "Sistem" },
            new() { Term = "7 Muda", Definition = "Taşıma-Stok-Hareket-Bekleme-Aşırı üretim-Aşırı işlem-Hata israf türleri", Category = "İsraf" },
            new() { Term = "Bottleneck", Definition = "Tüm akışı yavaşlatan en kısıtlı süreç adımı", Category = "Analiz" },
            new() { Term = "Value Stream", Definition = "Ürünün hammaddeden müşteriye ulaşmasındaki tüm adımlar dizisi", Category = "Analiz" },
            new() { Term = "Continuous Flow", Definition = "Ürünün durmadan bir adımdan diğerine aktığı kesintisiz üretim", Category = "Sistem" },
        };

        context.LeanTerms.AddRange(terms);
        context.SaveChanges();
    }
}
