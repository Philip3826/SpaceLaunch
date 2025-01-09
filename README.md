# SpaceLaunch
Assessment task from Hitachi Solutions

## How to use the console application

1. Start the console application.
2. Provide the full path to a CSV file on your computer when prompted.
3. Provide a Gmail address and password:
   - Go to your Google Account > Security.
   - If 2-Step-Authentication is activated, generate a password for the application from the App passwords section.
   - On the App form, select "Mail" and on the device form, select "Windows computer".
   - Google will generate a password that you can use for the application.
4. Provide the email address that will receive the message.
1. **This process is currently not working as described**

## Format of the CSV file

- **Day**: Integer between 1 and 31
- **Temperature**: Integer
- **Wind**: Positive integer
- **Humidity**: Percentage number
- **Precipitation**: Percentage number
- **Lightning**: "Yes" or "No" string
- **Clouds**: String describing the type of clouds

## CI/CD Process

### Continuous Integration (CI) Pipeline

The CI pipeline is defined in the `.github/workflows/CI.yml` file and is triggered on the following events:
- Push to the `dev` branch
- Pull request to the `dev` or `master` branch
- Manual dispatch

The CI pipeline consists of the following jobs:

1. **Build and Static Analysis (build-sast)**
2. **Snyk Vulnerability Scan (snyk)**
3. **Kubernetes Configuration Scan (scan-k8s-config)**
4. **Docker Build and Push (docker-build-image)**

####  Notes:

Each of the scans in the CI pipeline uploads found issues and vulnerabilities as sarif files in GitHub and a list of them 
can be found in the Security tab.

### Continuous Deployment (CD) Pipeline

The CD pipeline is defined in the `.github/workflows/CD.yaml` file and is triggered on the following events:
- Completion of the CI pipeline which deploys the app to a local minikube cluster.
- Manual dispatch which has the user choose whether to deploy to the local minikube cluster or to a AWS EKS.

The CD pipeline consists of the following jobs:

1. **Deploy to Minikube (deploy-to-minikube)**
2. **Deploy to AWS (deploy-to-aws)**

#### Notes:

Minikube cluster also runs a kube-bench job that checks if the cluster is deployed securely.

## Kubernetes configuration

In the `./Kubernetes` folder we can find the configuration files needed to run the Kubernetes cluster(minikube or AWS EKS).

1. **JobDeployment.yaml** runs the app as a job inside the cluster when deployed.
2. **KubeBenchJob.yaml** is a config file for the kube-bench job and is directly taken from kube-bench documentation.
1. **KubeLintConfig.yaml** is a config file for the kube-lint job and is used to exclude some checks that fail the job but are only warning level.

