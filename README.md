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

Bular shu kungacha to‘plangan ma'lumotlar. Ertaga davom etamiz.
