﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seq.Api.Model.AppInstances;

namespace Seq.Api.ResourceGroups
{
    public class AppInstancesResourceGroup : ApiResourceGroup
    {
        internal AppInstancesResourceGroup(ISeqConnection connection)
            : base("AppInstances", connection)
        {
        }

        public async Task<AppInstanceEntity> FindAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            return await GroupGetAsync<AppInstanceEntity>("Item", new Dictionary<string, object> { { "id", id } }).ConfigureAwait(false);
        }

        public async Task<List<AppInstanceEntity>> ListAsync()
        {
            return await GroupListAsync<AppInstanceEntity>("Items", new Dictionary<string, object> { { "runOnExisting", false } }).ConfigureAwait(false);
        }

        public async Task<AppInstanceEntity> TemplateAsync(string appId)
        {
            if (appId == null) throw new ArgumentNullException("appId");
            return await GroupGetAsync<AppInstanceEntity>("Template", new Dictionary<string, object> { { "appId", appId } }).ConfigureAwait(false);
        }

        public async Task<AppInstanceEntity> AddAsync(AppInstanceEntity entity)
        {
            return await Client.PostAsync<AppInstanceEntity, AppInstanceEntity>(entity, "Create", entity).ConfigureAwait(false);
        }

        public async Task RemoveAsync(AppInstanceEntity entity)
        {
            await Client.DeleteAsync(entity, "Self", entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(AppInstanceEntity entity)
        {
            await Client.PutAsync(entity, "Self", entity).ConfigureAwait(false);
        }
    }
}