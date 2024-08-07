﻿using Robust.Cdn.Services;

namespace Robust.Cdn.Config;

public sealed class CdnOptions
{
    public const string Position = "Cdn";

    /// <summary>
    /// Backwards-compatibility "default" fork value for content stored by an older version of <c>Robust.Cdn</c>.
    /// </summary>
    /// <remarks>
    /// When migrating a content database from an older version, this fork name will be assigned to existing content.
    /// Furthermore, the old <c>/version</c> endpoint will use this fork as the one to look up.
    /// </remarks>
    public string? DefaultFork { get; set; }

    /// <summary>
    /// File path for the database to store files, versions and logs into.
    /// </summary>
    public string DatabaseFileName { get; set; } = "content.db";

    /// <summary>
    /// Whether to do stream compression over whole download requests.
    /// Ignored if AutoStreamCompressRatio is used.
    /// </summary>
    public bool StreamCompress { get; set; } = false;

    /// <summary>
    /// Compression level for stream compression.
    /// </summary>
    public int StreamCompressLevel { get; set; } = 5;

    /// <summary>
    /// Whether to compress blobs on-disk. You probably want to leave this on.
    /// </summary>
    public bool BlobCompress { get; set; } = true;

    /// <summary>
    /// Compression level for on-disk compression.
    /// </summary>
    public int BlobCompressLevel { get; set; } = 18;

    /// <summary>
    /// The amount of bytes blob compression needs to save for it to be considered "worth it".
    /// Otherwise no compression is used.
    /// </summary>
    public int BlobCompressSavingsThreshold { get; set; } = 10;

    /// <summary>
    /// Whether to send on-disk compressed blobs over the network as pre-compression.
    /// Ignored if AutoStreamCompressRatio is used.
    /// </summary>
    public bool SendPreCompressed { get; set; } = true;

    /// <summary>
    /// Compression level to use for content manifests.
    /// </summary>
    public int ManifestCompressLevel { get; set; } = 18;

    /// <summary>
    /// Ratio of total files that need to be sent after which we switch to stream compression automatically.
    /// If this is enabled (disable by setting to a negative number),
    /// SendPreCompressed and StreamCompress are ignored and decided automatically.
    /// </summary>
    /// <remarks>
    /// Stream compression is generally better for large downloads, whereas individual is better for small downloads.
    /// This default value is arbitrarily decided without scientific testing or measurement.
    /// </remarks>
    public float AutoStreamCompressRatio { get; set; } = 0.5f;

    /// <summary>
    /// Log all download requests
    /// </summary>
    public bool LogRequests { get; set; } = false;

    /// <summary>
    /// Log download requests to database or console
    /// </summary>
    public RequestLogStorage LogRequestStorage { get; set; } = RequestLogStorage.Database;
}
