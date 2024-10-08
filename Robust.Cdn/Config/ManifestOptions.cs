﻿namespace Robust.Cdn.Config;

public sealed class ManifestOptions
{
    public const string Position = "Manifest";

    /// <summary>
    /// File path for the database to store data in for the manifest system.
    /// </summary>
    public string DatabaseFileName { get; set; } = "manifest.db";

    public string FileDiskPath { get; set; } = "";

    public Dictionary<string, ManifestForkOptions> Forks { get; set; } = new();

    /// <summary>
    /// Time, in minutes, before an in-progress publish "times out" and can be deleted.
    /// </summary>
    /// <remarks>
    /// Generally, publishes really should not take longer than more than a few minutes.
    /// If a publish takes longer, it likely indicates an error caused it to be aborted.
    /// </remarks>
    public int InProgressPublishTimeoutMinutes { get; set; } = 60;
}

public sealed class ManifestForkOptions
{
    public string? UpdateToken { get; set; }

    /// <summary>
    /// The name of client zip files in the directory structure, excluding the ".zip" extension.
    /// </summary>
    public string ClientZipName { get; set; } = "SS14.Client";

    public string ServerZipName { get; set; } = "SS14.Server_";

    public ManifestForkNotifyWatchdog[] NotifyWatchdogs { get; set; } = [];

    public bool Private { get; set; } = false;

    public Dictionary<string, string> PrivateUsers { get; set; } = new();

    /// <summary>
    /// If set to a value other than 0, old manifest versions will be automatically deleted after this many days.
    /// </summary>
    /// <remarks>
    /// This does not delete these old versions from the client CDN, only the server manifest.
    /// This is seen as acceptable as those generally don't take too much space.
    /// </remarks>
    public int PruneBuildsDays { get; set; } = 90;

    public string? DisplayName { get; set; }
    public string? BuildsPageLink { get; set; }
    public string? BuildsPageLinkText { get; set; }
}

public sealed class ManifestForkNotifyWatchdog
{
    public required string WatchdogUrl { get; set; }
    public required string Instance { get; set; }
    public required string ApiToken { get; set; }
}
