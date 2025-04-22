# Assalomu alkaykum!
### ushbu repository Axadio tili haqida

## O'rnatish

1. Git orqali klonlang:
```bash
git clone https://github.com/axadio/AXADIO-PL.git
```
## Bizning reja
1. Maqsad
  - Nima uchun bu til ishlatiladi?
  - Aynan qaysi jihati ustun bo'lishi kerak?
  - O'rganish uchunmi yoki real loyihalar uchun?


# 📘 Axadio Dasturlash Tili - Hujjat

## 1. Izohlar

Izoh yozish uchun ikkitalik qavs ishlatiladi:

```axadio
(( bu izoh ))
```

Ko‘p qatorli izoh:

```axadio
((
   bu birinchi qator
   bu ikkinchi
))
```

---

## 2. Ma'lumot turlari

| Kalit so‘z  | Tavsifi                        |
|-------------|--------------------------------|
| `raqam`     | 0–10 oralig‘idagi butun sonlar |
| `belgi`     | Bitta belgi (`char`)           |
| `son`       | Har qanday butun son (`int`)   |
| `kasr`      | Kasrli son (`float`)           |
| `mantiqan`  | Mantiqiy qiymat (`true/false`) |
| `quruq`     | Hech qanday qiymat qaytarmaydi |

---

## 3. Qator yakunlari

Har bir kod qatori **nuqta (.)** bilan emas, **tire (-)** bilan tugallanadi.

**Xato:**
```axadio
son a = 5.
```

**To‘g‘ri:**
```axadio
son a = 5 -
```

---

## 4. Belgilash qoidalari

Axadio tili C# asosida yaratilgani sababli, o‘zgaruvchilar nomini `snake_case` emas, `PascalCase` yoki `camelCase` da yozish tavsiya etiladi.

**Yaxshi:**
```axadio
son MeningSonim -
```

**Muammoli:**
```axadio
son mening_sonim -
```

---

## 5. Funktsiyalar

- **Quruq ma'lumot turi** hech qanday qiymat qaytarmaydi.

- **Funksiya yozish sintaksisi**:  
  `qaytarishTipi funksiyaNomi -> arg1, arg2 <- qaytarishTipi --tana--`

  **Xato:**
  ```axadio
  funksiyaNomi(arg1, ...) { tana }
  ```

  **To‘g‘ri:**
  ```axadio
  funksiyaNomi -> arg1, arg2 <- qaytarishTipi --
      tana
  --
  ```

- **Funksiya o‘zgarishi (return)**:  
  `return` so‘zi o‘rniga `uzat` ishlatiladi.

**Yaxshi:**
```axadio
funksiyaNomi -> arg1, arg2 <- son --
    son a = 5 -
    uzat a -
--
```

**Muammoli:**
```axadio
funksiyaNomi(arg1, arg2) { return a; }
```

---

## ✅ 6. Funksiyani chaqirish

Axadio tilida funksiyani chaqirish sintaksisi aniq va tartibli:

### 🔹 Sintaksis

```axadio
FunksiyaNomi <tur1 argument1, tur2 argument2> -
```

## 🔁 7. Ichma-ich chaqiruv (rekursiv funksiyalar)

Axadio tilida **rekursiv funksiyalarni chaqirishda** maxsus sintaksis mavjud. Har bir chaqiruv **qaytish nuqtalari (base case)** bilan birga yoziladi.

---

### 🔹 Sintaksis

```axadio
FunksiyaNomi<argument><holat1, qaytish1><holat2, qaytish2>
```

### Misol
```axadio
faktorial ->son son1<- son: <1, 1><0, 1>
--
  uzat son * faktorial<son - 1> -
--
```
## Standart holda 100 martagacha rekursiya chegaralangan.

## 🔄 8. Ma'lumot turini almashtirish (Type Casting)

Axadio tilida **qiymatning turini o‘zgartirish (casting)** `<- tur` sintaksisi orqali amalga oshiriladi.

Bu usul minimal sintaksis bilan **xotira tejamkor va qat'iy nazoratli** tur almashtirish imkonini beradi.

---

### 🔹 Sintaksis

```axadio
yangiQiymat = eskiQiymat <- yangiTur -
```

## 🖨️ 9. Kiritish va chiqarish
Kiritish va chiqarish uchun funksiyalar **standart** kutubxonasi mavjud, va undan foydalanish uchun **ishlatimoqda:** kalit so’zi kerak bo’ladi.

```axadio
ishlatilmoqda: "standart" - 
satr xabar = "Salom, Dunyo" - 
chiqarish<xabar> - 
satr ism = kiritish<"Ismingiz: "> - 
chiqarish<"Salom", ism> -
```
## ⁉️ 10. Shart Operatori (Conditional Statements)

Axadio tilida **shartki** operatori shartni tekshiradi va uning rost yoki yolg‘onligini aniqlaydi. Agar shart bajarilsa, tegishli tana bajariladi. Agar shart bajarilmasa, **yo‘qsa** operatori orqali aksi holat bajariladi.

### Sintaksis:

```axadio
shartki shart -- tana -
-- yo‘qsa shartki shart -- tana -
-- yo‘qsa -- tana -
```
```axadio
shartki 2 > 5
--
chiqarish<"2 5dan katta"> -
--
yo‘qsa shartki 2 > 3
--
chiqarish<"2 3dan katta"> -
--
yo‘qsa
--
chiqarish<"2 3 va 5dan kichik"> -
--
```

### Arifmetik qisqa yozuvlar

Axadio tilida qiymatga arifmetik amallarni sodda tarzda bajarish uchun quyidagi sintaksis ishlatiladi:

```axadio
son =+ 1  (( qiymatga 1 qo‘shish ))
son =- 2  (( qiymatdan 2 ayirish ))
son =* 3  (( qiymatni 3 ga ko‘paytirish ))
son =/ 4  (( qiymatni 4 ga bo‘lish ))


