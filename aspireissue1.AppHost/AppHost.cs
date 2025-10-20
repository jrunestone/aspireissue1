using Azure.Provisioning.KeyVault;

var builder = DistributedApplication.CreateBuilder(args);

builder
    .AddAzureKeyVault("kv-hgfse-dev-swc")
    .ConfigureInfrastructure(cfg =>
    {
        var kv = cfg.GetProvisionableResources().OfType<KeyVaultService>().Single();
        kv.Name = "kv-hgfse-dev-swc";
        kv.Properties.EnablePurgeProtection = true;
        kv.Properties.EnableSoftDelete = true;
    });

var app = builder.Build();
app.Run();
