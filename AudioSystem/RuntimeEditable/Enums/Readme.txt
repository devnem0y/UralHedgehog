0. !Файл Assembly "UralHedgehog.Audio.AudioSystem" не удалять!

1. Создать в каком либо скрипте на ваше усмотрение экземпляр AudioManager и передать в него AudioMixer, AudioResources (new AudioManager(AudioMixer, AudioResources))
2. Добавить имя в соответствующий Enum (AudioEnums) (!Не удалять файл, только добавлять нужные значения! Если вдруг удалили, можно добавить через Create - Ural Hedgehog - Audio System - AudioEnums Script)
3. Добавить дорожку в AudioResources и настроить по усмотрению (Create - Ural Hedgehog - Audio System - AudioResources)
4. Чтобы добавить звук или музыку, вешаем AudioComponent на объект
5. В скрипте своего объекта вызвать Audio.Init() (Убедиться что до этого был создан AudioManager)
6. В скрипте объекта получить компонент AudioComponent и вызвать Play();

0. !The Assembly file "UralHedgehog.Audio.AudioSystem" do not delete!

1. Create an instance of AudioManager in any script at your discretion and pass AudioMixer, AudioResources (new AudioManager(AudioMixer, AudioResources)) to it
2. Add the name to the corresponding Enum (AudioEnums) (!Do not delete the file, just add the necessary values! If you suddenly deleted it, you can add it via Create - Ural Hedgehog - Audio System - AudioEnums Script)
3. Add a track to AudioResources and customize it as you wish (Create - Ural Hedgehog - Audio System - AudioResources)
4. To add sound or music, we hang the AudioComponent on the object.
5. In the script of your object, call Audio.Init() (Make sure that AudioManager was created before that)
6. In the object script, get the AudioComponent component and call Play();