using System;
using System.Threading.Tasks;

using EventStore.ClientAPI;

namespace Memstate.EventStore
{
    public class EventStoreProvider : StorageProvider, IAsyncDisposable
    {
        private readonly IEventStoreConnection _connection;

        private readonly MemstateSettings _memstateSettings;
        
        private readonly EventStoreSettings _eventStoreSettings;

        public EventStoreProvider(MemstateSettings memstateSettings)
        {
            _memstateSettings = memstateSettings;
            _eventStoreSettings = Settings.Read<EventStoreSettings>();
            _connection = EventStoreConnection.Create(_eventStoreSettings.ConnectionString);
            _connection.ConnectAsync().Wait();
        }

        public override IJournalReader CreateJournalReader()
        {
            return new EventStoreReader(_memstateSettings, _eventStoreSettings, _connection);
        }

        public override IJournalWriter CreateJournalWriter(long nextRecordNumber)
        {
            return new EventStoreWriter(_eventStoreSettings, _connection);
        }

        public override IJournalSubscriptionSource CreateJournalSubscriptionSource()
        {
            return new EventStoreSubscriptionSource(_eventStoreSettings, _connection);
        }

        public Task DisposeAsync()
        {
            return Task.Run((Action)_connection.Close);
        }
    }
}