using System.Net;

namespace KubeDashboard.Model;

public record class LoadBalancerConfiguration(
    IList<string> ExternalIPs,
    IList<ServicePort> Ports);

public record class ServicePort(
    int Port,
    int TargetPort,
    string Protocol);