select ad, soyad, birim_ad, unvan_calisan, ikramiye_ucret from ikramiye 
left join calisanlar on ikramiye.ikramiye_calisan_id = calisanlar.calisan_id 
left join unvan on ikramiye.ikramiye_calisan_id = unvan.unvan_calisan_id 
left join birimler on calisanlar.calisan_birim_id = birimler.birim_id