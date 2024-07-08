n,m=map(int,input().split())
arr=list(map(int,input().split()))
pre_sum=[0]
for i in range(1,n):
    val=pre_sum[i-1]
    if arr[i]>=arr[i-1]:
        val+=0
    else:
        val+=(abs(arr[i]-arr[i-1]))
    pre_sum.append(val)

rev=[0]*n
for i in range(n-2,-1,-1):
    val=rev[i-1]
    if arr[i]>=arr[i+1]:
        val+=0
    else:
        val+=(abs(arr[i]-arr[i+1]))
    rev[i]=(val)

for i in range(m):
    s,j=map(int,input().split())
    if s<j:
        print(pre_sum[j-1]-pre_sum[s-1])
    else:
        print(rev[s-1]-rev[j-1])
