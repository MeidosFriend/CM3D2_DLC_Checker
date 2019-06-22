#Version 3, Using update from repo
import time
import requests
import os
from colorama import init
from termcolor import colored, cprint
init()

start = time.time()

#Check connection
#if connection is available, Check Update DLC list from repo
#Write new DLC list if current DLC list is old
url='https://raw.githubusercontent.com/Tankerch/CM3D2_DLC_Checker/master/CM_NewListDLC.lst'
def check_internet():
    timeout=3
    try:
        requests.get(url, timeout=timeout)
        return True
    except requests.ConnectionError:
        pass
    return False

if check_internet():
    r = requests.get(url, timeout=3)
    if os.path.isfile('CM_NewListDLC.lst'):
        with open('CM_NewListDLC.lst', 'r') as f:
            first_line_DLC = int(f.readline().rstrip('\n'))
        first_line_update = r.text.splitlines()[0]
        if first_line_update != "404: Not Found":
            first_line_update = int(first_line_update)
            if first_line_update > first_line_DLC:
                with open('CM_NewListDLC.lst', 'wb') as f:
                    f.write(r.content)
        else:
            input("Failed to download DLC list, please contact author")
            exit()
    else:
        if r.text.splitlines()[0] != "404: Not Found":
            with open('CM_NewListDLC.lst', 'wb') as f:
                f.write(r.content)
        else:
            input("Failed to download DLC list, please contact author")
            exit()
else:
    if not os.path.isfile('CM_NewListDLC.lst'):
        input("CM_NewListDLC.lst doesn't exist, please connect to the internet redownload it")
        exit()

#Start
print(colored("=====================================================================================================", 'cyan',attrs=['bold']))
print(colored('CM_DLC_Checker', 'cyan',attrs=['bold']))
print(colored("=====================================================================================================", 'cyan',attrs=['bold']))

#Open file and removing header for DLC List
line_inform = []
with open('CM_NewListDLC.lst', 'r') as f:
    for _ in range(1):
        next(f)
    for line in f:
        line_inform.append(line.rstrip('\n').split(","))
line_DLC = set(list(zip(*line_inform))[0])
line_informset = set(list(zip(*line_inform))[1])

#Make a set from gamedata
line_Real = set(os.listdir("GameData"))
#line_Real = set(line.strip().split(",")[0] for line in open('Update.lst', 'r'))

#Searching with intersection and linear remove searching
count_p = set()
for x in line_DLC.intersection(line_Real):
    for y in line_inform:
        if x == y[0]:
            count_p.add(y[1])
            line_inform.remove(y)
            break

#Separating installed with not installed
count_n = line_informset.difference(count_p)

#Show time
print(colored('Already Installed:', 'cyan',attrs=['bold']))
for x in sorted(count_p):
    print(x)

print(colored("\nNot Installed:", 'cyan',attrs=['bold']))
for x in sorted(count_n):
    print(x)

#Ending & Note
end = time.time()
print("\n\nElapsed time:", end-start)
text = input("Press Enter to end program")
