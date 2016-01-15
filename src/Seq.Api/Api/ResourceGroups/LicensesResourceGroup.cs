﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seq.Api.Model.Inputs;
using Seq.Api.Model.License;

namespace Seq.Api.ResourceGroups
{
    public class LicensesResourceGroup : ApiResourceGroup
    {
        internal LicensesResourceGroup(ISeqConnection connection)
            : base("Licenses", connection)
        {
        }

        public async Task<LicenseEntity> FindAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            return await GroupGetAsync<LicenseEntity>("Item", new Dictionary<string, object> { { "id", id } }).ConfigureAwait(false);
        }

        public async Task<LicenseEntity> FindCurrentAsync()
        {
            return await GroupGetAsync<LicenseEntity>("Current").ConfigureAwait(false);
        }

        public async Task<List<LicenseEntity>> ListAsync()
        {
            return await GroupListAsync<LicenseEntity>("Items").ConfigureAwait(false);
        }

        public async Task UpdateAsync(LicenseEntity entity)
        {
            await Client.PutAsync(entity, "Self", entity).ConfigureAwait(false);
        }

        public async Task DowngradeAsync()
        {
            await GroupPostAsync("Downgrade", new object()).ConfigureAwait(false);
        }
    }
}