using AbbreviationQuiz.Api.Models;

namespace AbbreviationQuiz.Api.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Abbreviations.Any()) return;

        var abbreviations = new List<Abbreviation>
        {
            // ── Stajyer ──────────────────────────────────────────────────────────
            // Bilgisayar kullanan herkesin bilmesi gereken şeyler

            new() { Short = "CPU", Full = "Central Processing Unit", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "GPU", Full = "Graphics Processing Unit", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "RAM", Full = "Random Access Memory", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "ROM", Full = "Read-Only Memory", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "SSD", Full = "Solid State Drive", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "HDD", Full = "Hard Disk Drive", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "USB", Full = "Universal Serial Bus", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "HDMI", Full = "High Definition Multimedia Interface", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "LCD", Full = "Liquid Crystal Display", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "LED", Full = "Light Emitting Diode", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "OLED", Full = "Organic Light Emitting Diode", Category = "Hardware", Level = "Stajyer" },
            new() { Short = "OS", Full = "Operating System", Category = "General", Level = "Stajyer" },
            new() { Short = "HTTP", Full = "HyperText Transfer Protocol", Category = "Networking", Level = "Stajyer" },
            new() { Short = "HTTPS", Full = "HTTP Secure", Category = "Networking", Level = "Stajyer" },
            new() { Short = "URL", Full = "Uniform Resource Locator", Category = "Web", Level = "Stajyer" },
            new() { Short = "IP", Full = "Internet Protocol", Category = "Networking", Level = "Stajyer" },
            new() { Short = "WiFi", Full = "Wireless Fidelity", Category = "Networking", Level = "Stajyer" },
            new() { Short = "ISP", Full = "Internet Service Provider", Category = "Networking", Level = "Stajyer" },
            new() { Short = "HTML", Full = "HyperText Markup Language", Category = "Web", Level = "Stajyer" },
            new() { Short = "CSS", Full = "Cascading Style Sheets", Category = "Web", Level = "Stajyer" },
            new() { Short = "JS", Full = "JavaScript", Category = "Web", Level = "Stajyer" },
            new() { Short = "API", Full = "Application Programming Interface", Category = "General", Level = "Stajyer" },
            new() { Short = "UI", Full = "User Interface", Category = "General", Level = "Stajyer" },
            new() { Short = "UX", Full = "User Experience", Category = "General", Level = "Stajyer" },
            new() { Short = "IDE", Full = "Integrated Development Environment", Category = "Development", Level = "Stajyer" },
            new() { Short = "GUI", Full = "Graphical User Interface", Category = "General", Level = "Stajyer" },
            new() { Short = "CLI", Full = "Command Line Interface", Category = "General", Level = "Stajyer" },
            new() { Short = "DB", Full = "Database", Category = "Database", Level = "Stajyer" },
            new() { Short = "SQL", Full = "Structured Query Language", Category = "Database", Level = "Stajyer" },
            new() { Short = "QA", Full = "Quality Assurance", Category = "Development", Level = "Stajyer" },
            new() { Short = "PDF", Full = "Portable Document Format", Category = "General", Level = "Stajyer" },
            new() { Short = "PNG", Full = "Portable Network Graphics", Category = "Graphics", Level = "Stajyer" },
            new() { Short = "JPEG", Full = "Joint Photographic Experts Group", Category = "Graphics", Level = "Stajyer" },
            new() { Short = "SVG", Full = "Scalable Vector Graphics", Category = "Graphics", Level = "Stajyer" },
            new() { Short = "CSV", Full = "Comma Separated Values", Category = "Data", Level = "Stajyer" },
            new() { Short = "JSON", Full = "JavaScript Object Notation", Category = "Data", Level = "Stajyer" },
            new() { Short = "FAQ", Full = "Frequently Asked Questions", Category = "General", Level = "Stajyer" },
            new() { Short = "SEO", Full = "Search Engine Optimization", Category = "Web", Level = "Stajyer" },

            // ── Junior ───────────────────────────────────────────────────────────
            // Çalışmaya başlayan bir dev'in öğrenmesi gereken temel teknik kavramlar

            // Ağ
            new() { Short = "TCP", Full = "Transmission Control Protocol", Category = "Networking", Level = "Junior" },
            new() { Short = "DNS", Full = "Domain Name System", Category = "Networking", Level = "Junior" },
            new() { Short = "SSH", Full = "Secure Shell", Category = "Networking", Level = "Junior" },
            new() { Short = "FTP", Full = "File Transfer Protocol", Category = "Networking", Level = "Junior" },
            new() { Short = "SMTP", Full = "Simple Mail Transfer Protocol", Category = "Networking", Level = "Junior" },
            new() { Short = "SSL", Full = "Secure Sockets Layer", Category = "Security", Level = "Junior" },
            new() { Short = "TLS", Full = "Transport Layer Security", Category = "Security", Level = "Junior" },
            new() { Short = "VPN", Full = "Virtual Private Network", Category = "Networking", Level = "Junior" },
            new() { Short = "LAN", Full = "Local Area Network", Category = "Networking", Level = "Junior" },
            new() { Short = "WAN", Full = "Wide Area Network", Category = "Networking", Level = "Junior" },
            new() { Short = "TTL", Full = "Time To Live", Category = "Networking", Level = "Junior" },

            // Donanım (bilmesi faydalı)
            new() { Short = "BIOS", Full = "Basic Input Output System", Category = "Hardware", Level = "Junior" },
            new() { Short = "PSU", Full = "Power Supply Unit", Category = "Hardware", Level = "Junior" },
            new() { Short = "NIC", Full = "Network Interface Card", Category = "Hardware", Level = "Junior" },
            new() { Short = "RAID", Full = "Redundant Array of Independent Disks", Category = "Hardware", Level = "Junior" },
            new() { Short = "NAS", Full = "Network Attached Storage", Category = "Hardware", Level = "Junior" },
            new() { Short = "NVMe", Full = "Non-Volatile Memory Express", Category = "Hardware", Level = "Junior" },
            new() { Short = "VRAM", Full = "Video Random Access Memory", Category = "Hardware", Level = "Junior" },

            // Yazılım temelleri
            new() { Short = "OOP", Full = "Object-Oriented Programming", Category = "Development", Level = "Junior" },
            new() { Short = "MVC", Full = "Model View Controller", Category = "Architecture", Level = "Junior" },
            new() { Short = "CRUD", Full = "Create Read Update Delete", Category = "Database", Level = "Junior" },
            new() { Short = "SDK", Full = "Software Development Kit", Category = "Development", Level = "Junior" },
            new() { Short = "DOM", Full = "Document Object Model", Category = "Web", Level = "Junior" },
            new() { Short = "CDN", Full = "Content Delivery Network", Category = "Web", Level = "Junior" },
            new() { Short = "REST", Full = "Representational State Transfer", Category = "Web", Level = "Junior" },
            new() { Short = "XML", Full = "Extensible Markup Language", Category = "Data", Level = "Junior" },
            new() { Short = "YAML", Full = "Yet Another Markup Language", Category = "Data", Level = "Junior" },
            new() { Short = "npm", Full = "Node Package Manager", Category = "Development", Level = "Junior" },
            new() { Short = "git", Full = "Global Information Tracker", Category = "Development", Level = "Junior" },
            new() { Short = "VCS", Full = "Version Control System", Category = "Development", Level = "Junior" },
            new() { Short = "DRY", Full = "Don't Repeat Yourself", Category = "Development", Level = "Junior" },
            new() { Short = "KISS", Full = "Keep It Simple Stupid", Category = "Development", Level = "Junior" },
            new() { Short = "YAGNI", Full = "You Aren't Gonna Need It", Category = "Development", Level = "Junior" },
            new() { Short = "RegEx", Full = "Regular Expression", Category = "Development", Level = "Junior" },
            new() { Short = "ENV", Full = "Environment Variable", Category = "Development", Level = "Junior" },

            // Veri / CS
            new() { Short = "ASCII", Full = "American Standard Code for Information Interchange", Category = "General", Level = "Junior" },
            new() { Short = "UTF", Full = "Unicode Transformation Format", Category = "General", Level = "Junior" },
            new() { Short = "FIFO", Full = "First In First Out", Category = "General", Level = "Junior" },
            new() { Short = "LIFO", Full = "Last In First Out", Category = "General", Level = "Junior" },
            new() { Short = "LRU", Full = "Least Recently Used", Category = "General", Level = "Junior" },
            new() { Short = "NoSQL", Full = "Not Only SQL", Category = "Database", Level = "Junior" },
            new() { Short = "ACID", Full = "Atomicity Consistency Isolation Durability", Category = "Database", Level = "Junior" },
            new() { Short = "ORM", Full = "Object Relational Mapping", Category = "Database", Level = "Junior" },
            new() { Short = "ERD", Full = "Entity Relationship Diagram", Category = "Database", Level = "Junior" },

            // Güvenlik
            new() { Short = "JWT", Full = "JSON Web Token", Category = "Security", Level = "Junior" },
            new() { Short = "OAuth", Full = "Open Authorization", Category = "Security", Level = "Junior" },
            new() { Short = "MFA", Full = "Multi-Factor Authentication", Category = "Security", Level = "Junior" },
            new() { Short = "XSS", Full = "Cross-Site Scripting", Category = "Security", Level = "Junior" },
            new() { Short = "CSRF", Full = "Cross-Site Request Forgery", Category = "Security", Level = "Junior" },
            new() { Short = "CORS", Full = "Cross-Origin Resource Sharing", Category = "Web", Level = "Junior" },
            new() { Short = "RBAC", Full = "Role-Based Access Control", Category = "Security", Level = "Junior" },

            // DevOps giriş / bulut
            new() { Short = "CI", Full = "Continuous Integration", Category = "DevOps", Level = "Junior" },
            new() { Short = "CD", Full = "Continuous Deployment", Category = "DevOps", Level = "Junior" },
            new() { Short = "DevOps", Full = "Development and Operations", Category = "DevOps", Level = "Junior" },
            new() { Short = "SaaS", Full = "Software as a Service", Category = "Cloud", Level = "Junior" },
            new() { Short = "PaaS", Full = "Platform as a Service", Category = "Cloud", Level = "Junior" },
            new() { Short = "IaaS", Full = "Infrastructure as a Service", Category = "Cloud", Level = "Junior" },
            new() { Short = "SLA", Full = "Service Level Agreement", Category = "DevOps", Level = "Junior" },
            new() { Short = "UUID", Full = "Universally Unique Identifier", Category = "General", Level = "Junior" },

            // Mimari giriş
            new() { Short = "DTO", Full = "Data Transfer Object", Category = "Architecture", Level = "Junior" },
            new() { Short = "DI", Full = "Dependency Injection", Category = "Architecture", Level = "Junior" },
            new() { Short = "SRP", Full = "Single Responsibility Principle", Category = "Architecture", Level = "Junior" },

            // ── Mid ──────────────────────────────────────────────────────────────
            // Birkaç yıl deneyimli bir dev'in bilmesi beklenen kavramlar

            // Mimari desenler
            new() { Short = "CQRS", Full = "Command Query Responsibility Segregation", Category = "Architecture", Level = "Mid" },
            new() { Short = "DDD", Full = "Domain Driven Design", Category = "Architecture", Level = "Mid" },
            new() { Short = "EDA", Full = "Event Driven Architecture", Category = "Architecture", Level = "Mid" },
            new() { Short = "SOA", Full = "Service Oriented Architecture", Category = "Architecture", Level = "Mid" },
            new() { Short = "SOLID", Full = "Single Responsibility Open Closed Liskov Substitution Interface Segregation Dependency Inversion", Category = "Architecture", Level = "Mid" },
            new() { Short = "SAGA", Full = "Saga Pattern", Category = "Architecture", Level = "Mid" },
            new() { Short = "CircuitBreaker", Full = "Circuit Breaker Pattern", Category = "Architecture", Level = "Mid" },
            new() { Short = "Idempotency", Full = "Idempotency Key Pattern", Category = "Architecture", Level = "Mid" },
            new() { Short = "MVVM", Full = "Model View ViewModel", Category = "Architecture", Level = "Mid" },
            new() { Short = "IoC", Full = "Inversion of Control", Category = "Architecture", Level = "Mid" },

            // Geliştirme pratikleri
            new() { Short = "TDD", Full = "Test Driven Development", Category = "Development", Level = "Mid" },
            new() { Short = "BDD", Full = "Behavior Driven Development", Category = "Development", Level = "Mid" },
            new() { Short = "SemVer", Full = "Semantic Versioning", Category = "Development", Level = "Mid" },
            new() { Short = "GraphQL", Full = "Graph Query Language", Category = "Web", Level = "Mid" },
            new() { Short = "gRPC", Full = "Google Remote Procedure Call", Category = "Networking", Level = "Mid" },
            new() { Short = "WebSocket", Full = "Web Socket Protocol", Category = "Networking", Level = "Mid" },
            new() { Short = "OpenAPI", Full = "Open Application Programming Interface", Category = "Web", Level = "Mid" },
            new() { Short = "SSR", Full = "Server Side Rendering", Category = "Web", Level = "Mid" },
            new() { Short = "CSR", Full = "Client Side Rendering", Category = "Web", Level = "Mid" },
            new() { Short = "WASM", Full = "WebAssembly", Category = "Web", Level = "Mid" },

            // Veritabanı ileri
            new() { Short = "WAL", Full = "Write Ahead Log", Category = "Database", Level = "Mid" },
            new() { Short = "OLAP", Full = "Online Analytical Processing", Category = "Database", Level = "Mid" },
            new() { Short = "OLTP", Full = "Online Transaction Processing", Category = "Database", Level = "Mid" },
            new() { Short = "MVCC", Full = "Multiversion Concurrency Control", Category = "Database", Level = "Mid" },
            new() { Short = "ETL", Full = "Extract Transform Load", Category = "Data", Level = "Mid" },
            new() { Short = "Protobuf", Full = "Protocol Buffers", Category = "Data", Level = "Mid" },

            // Güvenlik ileri
            new() { Short = "WAF", Full = "Web Application Firewall", Category = "Security", Level = "Mid" },
            new() { Short = "mTLS", Full = "Mutual Transport Layer Security", Category = "Security", Level = "Mid" },
            new() { Short = "PKCE", Full = "Proof Key for Code Exchange", Category = "Security", Level = "Mid" },
            new() { Short = "DMZ", Full = "Demilitarized Zone", Category = "Networking", Level = "Mid" },

            // DevOps / observability
            new() { Short = "IaC", Full = "Infrastructure as Code", Category = "DevOps", Level = "Mid" },
            new() { Short = "SRE", Full = "Site Reliability Engineering", Category = "DevOps", Level = "Mid" },
            new() { Short = "K8s", Full = "Kubernetes", Category = "DevOps", Level = "Mid" },
            new() { Short = "ELK", Full = "Elasticsearch Logstash Kibana", Category = "DevOps", Level = "Mid" },
            new() { Short = "APM", Full = "Application Performance Monitoring", Category = "DevOps", Level = "Mid" },
            new() { Short = "SLO", Full = "Service Level Objective", Category = "DevOps", Level = "Mid" },
            new() { Short = "SLI", Full = "Service Level Indicator", Category = "DevOps", Level = "Mid" },
            new() { Short = "MTTR", Full = "Mean Time To Recovery", Category = "DevOps", Level = "Mid" },
            new() { Short = "RTO", Full = "Recovery Time Objective", Category = "DevOps", Level = "Mid" },
            new() { Short = "RPO", Full = "Recovery Point Objective", Category = "DevOps", Level = "Mid" },
            new() { Short = "P99", Full = "99th Percentile Latency", Category = "DevOps", Level = "Mid" },
            new() { Short = "DORA", Full = "DevOps Research and Assessment", Category = "DevOps", Level = "Mid" },
            new() { Short = "Canary", Full = "Canary Deployment", Category = "DevOps", Level = "Mid" },
            new() { Short = "BlueGreen", Full = "Blue Green Deployment", Category = "DevOps", Level = "Mid" },
            new() { Short = "GitOps", Full = "Git Operations", Category = "DevOps", Level = "Mid" },

            // ── Senior ───────────────────────────────────────────────────────────
            // Her deneyimli dev'in bilmesi gereken kavramlar — rol bağımsız

            new() { Short = "CAP", Full = "Consistency Availability Partition Tolerance", Category = "Architecture", Level = "Senior" },
            new() { Short = "BASE", Full = "Basically Available Soft State Eventually Consistent", Category = "Database", Level = "Senior" },
            new() { Short = "EventSourcing", Full = "Event Sourcing", Category = "Architecture", Level = "Senior" },
            new() { Short = "HexArch", Full = "Hexagonal Architecture", Category = "Architecture", Level = "Senior" },
            new() { Short = "StranglerFig", Full = "Strangler Fig Pattern", Category = "Architecture", Level = "Senior" },
            new() { Short = "Sidecar", Full = "Sidecar Pattern", Category = "Architecture", Level = "Senior" },
            new() { Short = "Outbox", Full = "Transactional Outbox Pattern", Category = "Architecture", Level = "Senior" },
            new() { Short = "ServiceMesh", Full = "Service Mesh", Category = "DevOps", Level = "Senior" },
            new() { Short = "CRD", Full = "Custom Resource Definition", Category = "DevOps", Level = "Senior" },
            new() { Short = "HPA", Full = "Horizontal Pod Autoscaler", Category = "DevOps", Level = "Senior" },
            new() { Short = "OPA", Full = "Open Policy Agent", Category = "Security", Level = "Senior" },
            new() { Short = "JIT", Full = "Just In Time Compilation", Category = "Development", Level = "Senior" },
            new() { Short = "AOT", Full = "Ahead Of Time Compilation", Category = "Development", Level = "Senior" },
            new() { Short = "GC", Full = "Garbage Collection", Category = "Development", Level = "Senior" },
            new() { Short = "AST", Full = "Abstract Syntax Tree", Category = "Development", Level = "Senior" },
            new() { Short = "POSIX", Full = "Portable Operating System Interface", Category = "General", Level = "Senior" },
            new() { Short = "RAFT", Full = "Reliable Replication Replicated And Fault Tolerant", Category = "Architecture", Level = "Senior" },
            new() { Short = "PAXOS", Full = "Paxos Consensus Algorithm", Category = "Architecture", Level = "Senior" },
            new() { Short = "CRDT", Full = "Conflict Free Replicated Data Type", Category = "Architecture", Level = "Senior" },
            new() { Short = "Amdahl", Full = "Amdahls Law", Category = "Architecture", Level = "Senior" },
        };

        context.Abbreviations.AddRange(abbreviations);
        context.SaveChanges();
    }
}
