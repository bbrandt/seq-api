﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seq.Api.Model.Settings;

namespace Seq.Api.ResourceGroups
{
    public class SettingsResourceGroup : ApiResourceGroup
    {
        internal SettingsResourceGroup(ISeqConnection connection)
            : base("Settings", connection)
        {
        }

        public async Task<SettingEntity> FindAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            return await GroupGetAsync<SettingEntity>("Item", new Dictionary<string, object> { { "id", id } }).ConfigureAwait(false);
        }

        public async Task<SettingEntity> FindNamedAsync(SettingName name)
        {
            return await GroupGetAsync<SettingEntity>(name.ToString()).ConfigureAwait(false);
        }

        public async Task<List<SettingEntity>> ListAsync()
        {
            return await GroupListAsync<SettingEntity>("Items").ConfigureAwait(false);
        }

        public async Task<SettingEntity> TemplateAsync()
        {
            return await GroupGetAsync<SettingEntity>("Template").ConfigureAwait(false);
        }

        public async Task<SettingEntity> AddAsync(SettingEntity entity)
        {
            return await Client.PostAsync<SettingEntity, SettingEntity>(entity, "Create", entity).ConfigureAwait(false);
        }

        public async Task RemoveAsync(SettingEntity entity)
        {
            await Client.DeleteAsync(entity, "Self", entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(SettingEntity entity)
        {
            await Client.PutAsync(entity, "Self", entity).ConfigureAwait(false);
        }
    }
}