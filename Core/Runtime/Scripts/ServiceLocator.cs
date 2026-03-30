using System.Collections.Generic;
using UnityEngine;

namespace UralHedgehog.Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<System.Type, object> _services = new();

        /// <summary>
        /// Регистрирует готовый экземпляр сервиса по его интерфейсу.
        /// </summary>
        /// <typeparam name="TInterface">Интерфейс сервиса (должен быть ссылочным типом)</typeparam>
        /// <param name="service">Экземпляр сервиса</param>
        /// <returns>Переданный экземпляр сервиса</returns>
        public static TInterface Register<TInterface>(TInterface service)
            where TInterface : class
        {
            var interfaceType = typeof(TInterface);

            if (service == null)
                throw new System.ArgumentNullException(nameof(service),
                    $"Невозможно зарегистрировать null как сервис типа {interfaceType.Name}");

            if (_services.ContainsKey(interfaceType))
            {
                Debug.LogWarning($"Сервис интерфейса {interfaceType.Name} уже зарегистрирован. Заменяем на новый.");
            }

            _services[interfaceType] = service;
            Debug.Log($"Зарегистрирован сервис интерфейса: {interfaceType.Name}");

            return service;
        }

        /// <summary>
        /// Автоматически создаёт экземпляр реализации и регистрирует по интерфейсу.
        /// </summary>
        /// <typeparam name="TInterface">Интерфейс сервиса</typeparam>
        /// <typeparam name="TImplementation">Реализация сервиса</typeparam>
        public static void Register<TInterface, TImplementation>()
            where TImplementation : class, TInterface, new()
            where TInterface : class
        {
            var service = new TImplementation();
            Register(service);
        }

        /// <summary>
        /// Получает зарегистрированный сервис по интерфейсу или классу.
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого сервиса</typeparam>
        /// <returns>Экземпляр сервиса или null, если не найден</returns>
        public static T Get<T>() where T : class
        {
            var serviceType = typeof(T);

            if (!_services.ContainsKey(serviceType))
            {
                Debug.LogError($"Сервис типа {serviceType.Name} не зарегистрирован!");
                return null;
            }

            return (T)_services[serviceType];
        }

        /// <summary>
        /// Безопасное получение сервиса без исключений.
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <param name="service">Найденный сервис (или null)</param>
        /// <returns>true, если сервис найден</returns>
        public static bool TryGet<T>(out T service) where T : class
        {
            var type = typeof(T);
            service = _services.ContainsKey(type) ? (T)_services[type] : null;
            return service != null;
        }

        /// <summary>
        /// Проверяет регистрацию сервиса.
        /// </summary>
        /// <typeparam name="T">Тип/интерфейс сервиса</typeparam>
        /// <returns>true, если зарегистрирован</returns>
        public static bool Has<T>() where T : class
        {
            return _services.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Удаляет сервис из локатора.
        /// </summary>
        /// <typeparam name="T">Тип/интерфейс сервиса</typeparam>
        public static void Unregister<T>() where T : class
        {
            var serviceType = typeof(T);
            if (_services.Remove(serviceType))
            {
                Debug.Log($"Удален сервис: {serviceType.Name}");
            }
        }

        /// <summary>
        /// Очищает все сервисы.
        /// </summary>
        public static void ClearAll()
        {
            _services.Clear();
            Debug.Log("Все сервисы очищены из Service Locator.");
        }
    }
}