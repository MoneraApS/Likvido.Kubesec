﻿namespace Likvido.Kubesec
{
    using System;
    using System.IO;

    public static class BackupCommand
    {
        public static int Run(string context)
        {
            var backupFolder = $"Kubesec_Backup_{context}_{DateTime.Now:yyyyMMddTHHmmss}";
            Directory.CreateDirectory(backupFolder);

            var allSecrets = KubeCtl.GetAllSecrets();

            foreach (var secret in allSecrets)
            {
                Utils.WriteToFile($"{backupFolder}/{secret.Key}.env", secret.Value, context, secret.Key);
            }

            return 0;
        }
    }
}