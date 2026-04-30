\# Data Flow



\## Data Export Request

1\. User submits request

2\. API validates request

3\. Request stored in DB

4\. Background job processes request

5\. Data compiled and stored

6\. User notified



\---



\## Data Deletion Request

1\. User submits deletion request

2\. Request stored

3\. Background job triggered

4\. Data soft deleted

5\. Hard delete scheduled

6\. Audit log recorded



\---



\## Consent Flow

1\. User gives consent

2\. Consent stored with version

3\. User can withdraw consent

4\. All changes logged

