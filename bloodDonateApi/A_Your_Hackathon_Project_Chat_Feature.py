t=int(input())
for _ in range(t):
    n=int(input())
    s=input()
    count=0
    while s[-1]==')':
        count+=1
        s=s[:-1]
    if len(s)<count:
        print('No')
    else:
        print('Yes')