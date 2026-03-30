# Ural Hedgehog Unity Packages

Набор модульных пакетов для Unity. Вы можете установить только нужные модули или весь набор с основным пакетом `Core`.

## Доступные пакеты

* **`Core`** — основной пакет с базовыми функциями.
* **`WidgetSystem`** — система UI.
* **`AudioSystem`** — аудиосистема.
* **`Localization`** — система локализации.
* **`DataSystem`** — система работы с данными.

## Установка

### Вариант 1. Установка Core со всеми зависимостями

Пакет `Core` зависит от всех остальных модулей. Чтобы установить его вместе с зависимостями:

В `manifest.json` подключить пакеты через путь:
```json
{
  "dependencies": {
    "com.uralhedgehog.widgetsystem": "https://github.com/devnem0y/UralHedgehog.git?path=/WidgetSystem",
    "com.uralhedgehog.localization": "https://github.com/devnem0y/UralHedgehog.git?path=/Localization",
    "com.uralhedgehog.audiosystem": "https://github.com/devnem0y/UralHedgehog.git?path=/AudioSystem",
    "com.uralhedgehog.datasystem": "https://github.com/devnem0y/UralHedgehog.git?path=/DataSystem",
    "com.uralhedgehog.core": "https://github.com/devnem0y/UralHedgehog.git?path=/Core"
  }
}
```

### Вариант 2. Выборочная установка отдельных пакетов

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
