# Ural Hedgehog Unity Packages

Набор модульных пакетов для Unity. Вы можете установить только нужные модули или весь набор с основным пакетом `Core`.

## Доступные пакеты

* **`Core`** — основной пакет с базовыми функциями.
* **`WidgetSystem`** — система UI‑виджетов.
* **`AudioSystem`** — аудиосистема.
* **`Localization`** — система локализации.
* **`DataSystem`** — система работы с данными.

## Установка

### Вариант 1. Выборочная установка отдельных пакетов

Если вам нужен только один или несколько пакетов без `Core`, установите их напрямую через Git URL:

1. Откройте Unity и ваш проект.
2. Перейдите в **Window → Package Manager**.
3. Нажмите кнопку **+** и выберите **Add package from git URL**.
4. Введите нужный URL и нажмите **Add**.

**URL‑адреса пакетов:**

* **WidgetSystem:** `https://github.com/devnem0y/UralHedgehog.git?path=/WidgetSystem`
* **AudioSystem:** `https://github.com/devnem0y/UralHedgehog.git?path=/AudioSystem`
* **Localization:** `https://github.com/devnem0y/UralHedgehog.git?path=/Localization`
* **DataSystem:** `https://github.com/devnem0y/UralHedgehog.git?path=/DataSystem`

Или в `manifest.json` подключить пакеты через путь:
```json
{
  "dependencies": {
    "com.uralhedgehog.widgetsystem": "https://github.com/devnem0y/UralHedgehog.git?path=/WidgetSystem",
    "com.uralhedgehog.localization": "https://github.com/devnem0y/UralHedgehog.git?path=/Localization",
    "com.uralhedgehog.audiosystem": "https://github.com/devnem0y/UralHedgehog.git?path=/AudioSystem",
    "com.uralhedgehog.datasystem": "https://github.com/devnem0y/UralHedgehog.git?path=/DataSystem"
  }
}
```

### Вариант 2. Установка Core со всеми зависимостями

Пакет `Core` зависит от всех остальных модулей. Чтобы установить его вместе с зависимостями:

1. **Сначала установите все зависимости** (в любом порядке):
   * WidgetSystem
   * AudioSystem
   * Localization
   * DataSystem

   Используйте **Add package from git URL** для каждого (см. URL в разделе выше).

2. **Затем установите основной пакет Core:**
   * В **Package Manager** нажмите **+ → Add package from git URL**.
   * Введите URL: `https://github.com/devnem0y/UralHedgehog.git?path=/Core`
   * Нажмите **Add**.
