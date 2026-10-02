# Service-oriented-Architecture
NWSDB Water Billing &amp; Payment System – Service-Oriented Architecture
Architected and implemented a decoupled SOA solution separating billing (NWSDB_MainAPI) and payment processing (Bank_ExternalAPI) into independent RESTful services.

Built a complete payment workflow with a 3rd-party client (Cargills POS) integrating via standard HTTP/JSON contracts.

Applied layered architecture (Controllers, DTOs, Repositories, Entity Framework Core) and implemented fault isolation, independent scaling, and graceful fallback.

Designed deployment strategy using Docker containerisation and Azure Kubernetes Service (AKS) with auto-scaling.
