
class Student:
    def __init__(self,name,surname,age):
        self.__name=name
        self.__surName=surname
        self.__age=age

    def GetSurname(self):
        return self.__surName

    def GetName(self):
        return self.__name

    def GetAge(self):
        return self.__age

    def SetName(self,value):
        self.__name=value

    def SetSurName(self,value):
        self.__surName=value

    def SetAge(self,value):
        self.__age=value

students=[]

def menu():
    print('**************** Menu *****************')
    print('1)Add Student')
    print('2)Edit Student')
    print('3)Delete Student')
    print('4)Print All Students')
    print('5)Exit')

def AddStudent(students):
    print('**************** Add Student Page *****************')
    name=input('Enter Name\t')
    surName=input('Enter SurName\t')
    age=int(input('Enter Age\t'))
    student=Student(name,surName,age)
    students.append(student)

def PrintStudents(students):
    print('**************** Print Student Page *****************')
    for item in students:
        print('Name '+item.GetName())
        print('SurName '+item.GetSurname())
        print('Age '+str(item.GetAge()))
        print('*************************')

def EditStudent(students):
    print('**************** Edit Student Page *****************')
    search=input('Enter Surname = ')
    find=False
    for item in students:
        if item.GetSurname()==search:
            name=input('Enter Name\t')
            surName=input('Enter SurName\t')
            age=int(input('Enter Age\t'))
            item.SetName(name)
            item.SetSurName(surName)
            item.SetAge(age)
            find=True
    if find==False:
        print('Not Found')

def DeleteStudent(students):
    print('**************** Delete Student Page *****************')
    search=input('Enter Surname = ')
    find=False
    for item in students:
        if item.GetSurname()==search:
            students.remove(item)
            find=True
    if find==False:
        print('Not Found')




while True:
    menu()
    select=input('')
    if select=='1':
        AddStudent(students)
    elif select=='2':
        EditStudent(students)
    elif select=='3':
        DeleteStudent(students)
    elif select=='4':
        PrintStudents(students)
    elif select=='5':
        pass
    else:
        print('Try Again ')