   M S B A M L   `   `   `  ���� 
  Medkit    Medkit.MenuWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f48extended)http://schemas.xceed.com/wpf/xaml/toolkit  -     �Name$  Window�� � Title$ 
MenuWindow�� � 
ResizeMode$ 	CanResize=� � WindowStyle$
 None=� � WindowState$ Normal=� � WindowStartupLocation$ CenterScreen=� � Icon$ Assets/Img/medkiticon.png��$
��1260��$	��600�� � SizeToContent$ Manual=�$
��1260��$	��600�����	#FFEEF9FB'  !System.Windows.Shell.WindowChrome   WindowChrome   	   CaptionHeight$	 0Q�
   ResizeBorderThickness$
 5q�.��� .+��� -    ��Name$ toolBar��$	��200��$
��Left=�$	��Top=�
�������$	��600������ *ActualHeight+ �� ElementName$ Window���� -   .���� -   $	��800��$��65�����	#FF388E3C$	��Top=�� $	��800��$��65��$	��Top=�.+��� -    ��Name$ 	labelName��$
��sdaw��
�������$��Right=�$,��&/Medkit;component/Fonts/#Roboto Medium)�$��20(�$��	0,5,130,0q�$	��Top=��� -   $ labelStatus��
�������$��Right=�$+��%/Medkit;component/Fonts/#Roboto Light)�$��18(�$��Bottom=�$��	0,0,130,5q�.��Сотрудник��  �� Orientation$ 
Horizontal=�$��Right=�$��0,0,10,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$# BadgeAccountHorizontalOutline=�$��50��$��50��
�������$��Right=�$��0,5,12,0q�$	��Top=��� -    &  "MaterialDesignIconForegroundButton#��[   � ToolTip$1 +Выход из учетной записи��$��Right=�.��  $��40��$��40��
�������$ 	ExitToApp=��� $ 
Horizontal=�.+��� $ 
Horizontal=�$
��Left=����� *ActualWidth+$ toolBar��.+��� $y�Visible=�$+��%/Medkit;component/Fonts/#Roboto Black)�$��36(�
�������$��Center=�$
��Left=�$��20,0,0,0q�.��Medkit�� $��3��
�������$��Right=�$��54,0,0,0q��� $	��200��$��Center=�$��Center=�.+��� -   $ clock��$+��%/Medkit;component/Fonts/#Roboto Light)�$��16(�
�������$��Center=�.��Время: 12:00�� -	   $ 	dateLabel��$+��%/Medkit;component/Fonts/#Roboto Light)�$��16(�
�������$��Bottom=�.��Дата: 13.05.2020�� $	��466��$��Center=�$��Center=�$��0q�.+��� $y�Visible=�$+��%/Medkit;component/Fonts/#Roboto Black)�$��22(�
�������$��Center=�$��Center=�$��20,0,0,0q�.��+)Поликлиника "Здоровье"�� $ 
Horizontal=�.+�� $��1��$
��Left=����� *ActualWidth+$ toolBar������ *ActualHeight+$ toolBar��.+�� -
    �Name$ 	UserPanel��.+��� $��0,85,0,0q�.+��� -   $��50�����	#FF388E3C  MaterialDesignFlatButton#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  -     Name$ iconHome��$��30��$��30��$ HomeAccount=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Рабочий стол�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ FileEdit=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Запись на прием�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ HumanMaleFemale=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Пациенты�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ Information=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��О программе� -   $ 
AdminPanel��$y�Hidden=�.+��� $��0,85,0,0q�.+��� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  -   $ IconHomeAdmin��$��30��$��30��$ HomeAccount=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Рабочий стол�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ Doctor=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Доктора�� -    ��Name$ AdminClients��$��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ HumanMaleFemale=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Пациенты�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ AccountGroup=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Учетные записи�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ Graph=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Статистика�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$	 Cog=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��Настройки�� -   $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $ 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ Information=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�$��16(�.��О программе� -   $ LeftGrid��$
��1030��$��Center=�$��15,0,0,0q�.+�� -   $ MainGrid�� � ColumnDefinitions �� $
��101* ��� $��2* �.+��� $ 
Horizontal=�$��0q�$��0��.+��� $��10,70,0,478q�$	��370��.+��� -    ��Name$ findTextBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��   
HelperText$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $ 
Horizontal=�$��
5,77,0,480q�$	��360��$	��Top=�.+��� -    " MaterialDesignRaisedDarkButton#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� -   #��[ $3 -Фильтры записей на прием��$��20,0,0,0q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��Фильтры�� -   $ WarFilt��$y�Hidden=�$��Center=�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��Bold"�$��10,0,0,0q�.��Фильтр включен!�� $��	0,130,0,0q�$��0��.+�&   System.Windows.Controls.DataGrid  -     Name$ dataWork��$��0 8 0 0q�   CanUserSortColumns .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    CanUserDeleteRows .  $   HorizontalScrollBarVisibility$ Disabled=�-  'MaterialDesignThemes.Wpf.DataGridAssist   ColumnHeaderPadding$ 8q�   CanUserAddRows .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader  �� BasedOn! �� 
TargetType" �� Property# �� Value��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$   RowDetailsTemplate$ �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �% � RowDefinitions% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� & �� Padding$& 5q�$!��Дата рождения: �����	#FF388E3C$
��Bold"�$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1������ *date+�� $& 5q�$��Телефон: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3������ *	telephone+�� $& 5q�$��Направление: �����	#FF388E3C$
��Bold"�$��1��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1��$��1������ *napr+�� $& 5q�$��
Врач: �����	#FF388E3C$
��Bold"�$��1��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1��$��3������ *
Врач+�� $& 5q�$��Тип: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��2��$��1������ *osmt+�� $& 5q�$��Кабинет: �����	#FF388E3C$
��Bold"�$��2��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��2��$��3������ *cab+�� $& 5q�$��
Цена: �����	#FF388E3C$
��Bold"�$��3��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3��$��1������ *pricer+�� $& 5q�$��Скидка: �����	#FF388E3C$
��Bold"�$��3��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3��$��3������ *disc+�� $��4��  MaterialDesignDarkSeparator#��[ $��4���� $ 
Horizontal=�$��5��$��4��$��Center=�$��Center=�.+��� -    #��[ $	��150��
�������$��Center=�$��0q����� ' �� Path$' id�.��Отменить запись�� $ 	TalonWord��-!   #��[ $	��150��
�������$��Center=�$
��10,0q����� $' id�.��Печать талона�� -"   #��[ $	��150��
�������$��Center=����� $' id�.��Прием завершен� -#   $ 	TalonGrid��$y�Hidden=�.+��� $��0,65,0,0q�.+��� $��Новый талон��  MaterialDesignCardGroupBox#���  $��16,16,30,16q�.  (MaterialDesignThemes.Wpf.ColorZoneAssist(   Mode$( Custom=�)   
Background) �	#FF388E3C*   
Foreground
* �����$	��500��$%��/Medkit;component/Fonts/#Roboto)�$��14(����� .R��� $ 
Horizontal=�.+�  $ TextBoxPlus=�$��32��$��32��$��Center=��� $��8,0,0,0q�$��Center=� $  MaterialDesignSubtitle1TextBlock#��[ $+��%/Medkit;component/Fonts/#Roboto Black)�$��20(����� .��� % �� $	��53* ��� $	��45* ��� $	��46* ��� $	��47* ��� $	��43* ��� $
��162* ��� $	��36* � �� $
��239* ��� $	��12* ��� $
��239* �.+��� -$   $ FamBox��$% Фамилия пациента��+   FloatingScale$
+ 0.90Q� % !MaterialDesignFloatingHintTextBox#��[ $��1��$��Bottom=�$��42��$��0q��� -%   $ NameBox��$ Имя пациента��$
+ 0.90Q�#��[ $��Bottom=�$��42��$��2��$��0q��� -&   $ OtchBox��$' !Отчество пациента��$
+ 0.90Q�#��[ $��Bottom=�$��42��$��3��$��0q�(	  "System.Windows.Controls.DatePicker	  -'   , 	 Name$, dateDay��$ Дата рождения��- � Language$- ru-RU� ( $MaterialDesignFloatingHintDatePicker#��[ $
+ 0.90Q�$��0,0,0,3q�$	��120��$��4��$��Stretch=�$
��Left=�%
  Xceed.Wpf.Toolkit.MaskedTextBox
  -(   . 
 Name$. PhoneBox��$ Телефон��/ 
  Mask$/ +79999999999��0 �� 	MaxLength$0 13��$
+ 0.90Q�#��[ $	��Top=�$	��150��$��42��$��5��$
��Left=��� $ 
Horizontal=�$��0��$
��Left=�$��Bottom=�$��42��$��0q�$	��471��.+��� $��4��$��Bottom=�$
��Left=�$%��/Medkit;component/Fonts/#Roboto)����	#FF515151$
��Bold"�.��Паспорт:�� -)   $ 	SerialBox��$0 4��$ 
Серия��$
+ 0.90Q�#��[ $��Center=�$��50��$��42��$��2��$
��Left=��� -*   $ NumPass��$0 6��$ 
Номер��$
+ 0.90Q�#��[ $��Center=�$��50��$��42��$��2��$
��Left=�$��5,0,0,0q��� -+   
�������$��4��$��Bottom=�$- 'Найти пациента в базе��$��17,0,0,0q�$��Right=�#��[ $��16(�.��
Найти�� -,   $ 	WrongData��$y�Hidden=�$��14(�$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=����	#00ECECEC���	#DDFF0000.��31Введите корректные данные!�� --   $ 	SaleLabel��$y�Hidden=�$��5��$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=�$��22��$��14(�.��GEНа данного клиента действует скидка 3%�� -.   $ 
WarningMsg��$y�Hidden=�$��5��$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=�$��22��$��14(�$��Right=����	#DDFF0000$	��143��.��%#Заполните все поля!�� -/   1 ��Name$1 	TypeTalon��$ Тип��$
+ 0.90Q� & "MaterialDesignFloatingHintComboBox#��[ $��2��$��42��$��Bottom=�.@��� .��!Первичный осмотр�� .��!Вторичный осмотр�� -0   $1 specBox��$ Направление��#��[ $��2��$��1��$��42��$��Bottom=�2 �� DisplayMemberPath$	2 Spl��$
+ 0.90Q�3 �� SelectedValuePath$	3 Num���� -1   $1 	doctorBox��$ Врач��#��[ $��2��$��2��$��42��$��0q�$��Bottom=�$	2 Fio��$
+ 0.90Q�$	3 Num��	  -2   $, datePrim��$- ru-RU�$ Дата приема��#��[ $��0,4,0,0q�$	��120��$��35��$��2��$��3��$	��Top=�$
��Left=�$
+ 0.90Q��� $��2��$��4��$��Bottom=�$%��/Medkit;component/Fonts/#Roboto)�$
��Bold"����	#FF515151$��22��$��0q�.��Время приема:�� $ Vertical=�$��5��$��2��$	��Top=�$	��162��.+�� -3   4 �Name$4 Panel��5 � Orientation$5 
Horizontal=�$��2q�$	��160��.+�	� -4   6 	�Name$6 Time0��  	 MaterialDesignTabRadioButton#��[	 $��4q�7 d� 	IsChecked$7 FalseY�$
��8:00��$y�Hidden=�	� -5   $6 Time1��#��[	 $��4q�$7 FalseY�$
��8:30��$y�Hidden=�	� -6   $6 Time2��#��[	 $��4q�$7 FalseY�$
��9:00��$y�Hidden=�	� -7   $6 Time3��#��[	 $��4q�$7 FalseY�$
��9:30��$y�Hidden=�	� -8   $6 Time4��#��[	 $��4q�$7 FalseY�$��10:00��$y�Hidden=�	� -9   $6 Time5��#��[	 $��4q�$7 FalseY�$��10:30��$y�Hidden=�	� -:   $6 Time6��#��[	 $��4q�$7 FalseY�$��11:00��$y�Hidden=�	� -;   $6 Time7��#��[	 $��4q�$7 FalseY�$��11:30��$y�Hidden=�	� -<   $6 Time8��#��[	 $��4q�$7 FalseY�$��12:00��$y�Hidden=�	� -=   $6 Time9��#��[	 $��4q�$7 FalseY�$��12:30��$y�Hidden=�	� ->   $6 Time10��#��[	 $��4q�$7 FalseY�$��13:30��$y�Hidden=�	� -?   $6 Time11��#��[	 $��4q�$7 FalseY�{�.  $��14:00��$y�Hidden=�	� -@   $6 Time12��#��[	 $��4q�$7 FalseY�$��14:30��$y�Hidden=�	� -A   $6 Time13��#��[	 $��4q�$7 FalseY�$��15:00��$y�Hidden=�	� -B   $6 Time14��#��[	 $��4q�$7 FalseY�$��15:30��$y�Hidden=�	� -C   $6 Time15��#��[	 $��4q�$7 FalseY�$��16:00��$y�Hidden=�	� -D   $6 Time16��#��[	 $��4q�$7 FalseY�$��16:30��$y�Hidden=�	� -E   $6 Time17��#��[	 $��4q�$7 FalseY�$��17:30��$y�Hidden=�	� -F   $6 Time18��#��[	 $��4q�$7 FalseY�$��18:00��$y�Hidden=�	� -G   $6 Time19��#��[	 $��4q�$7 FalseY�$��18:30��$y�Hidden=��� $��2��$��6��$ 
Horizontal=�.+��� $��6��$%��/Medkit;component/Fonts/#Roboto)�$��18(�$��Bottom=�$
��Bold"�.��	Цена:�� -H   $ 
PriceLabel��$��6��$%��/Medkit;component/Fonts/#Roboto)�$��18(�$��Bottom=��� -I   $ AddTalon��
�������$��6��$��Bottom=�$) #Сформировать талон��$��0q�#��[ $%��/Medkit;component/Fonts/#Roboto)�$��16(�.��Добавить талон� -J   $ 
ClientGrid��$y�Hidden=� �� $
��259* ��� $
��259* �.+��� $ 
Horizontal=�$��0q�$��0��.+��� $��10,70,0,478q�$	��370��.+��� -K   $ ClinentFindTextBox��$ 
Поиск��$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $��
5,77,0,480q�.+��� -L   $ FindClientBut��#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� $��	0,130,0,0q�$��0��.+�  -M   $ ClientDataGrid��$��0 8 0 0q� . $ *  .  $ 8q� .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  ��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$ �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $& 5q�$!��Дата рождения: �����	#FF388E3C$
��Bold"�$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1������ *dt+�� $& 5q�$��Телефон: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3������ *	telephone+� -N   $ 
GridTalons��$��1��$y�Hidden=�.+��� $ 
Horizontal=�$
��10,0q�.+��� $��10,70,0,478q�$	��370��.+��� -O   $ ClinentFindTalonTextBox��$ 
Поиск��$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $��
5,77,0,480q�.+��� -P   $ TalonGridTwoFind��#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� $��
9,130,20,0q�.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0,0,10,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(�.��� $5 
Horizontal=�.+��� -Q   $ ClientNameLabel��$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��KIЗаписи на прием Иванова Ивана Ивановича  -R   $ ClientDataTalonGrid��$��0,8,10,0q� . $ *  .  $ 8q� .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  ��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$ �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $& 5q�$!��Дата рождения: �����	#FF388E3C$
��Bold"�$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1������ *date+�� $& 5q�$��Телефон: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3������ *	telephone+�� $& 5q�$��Направление: �����	#FF388E3C$
��Bold"�$��1��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1��$��1������ *napr+�� $& 5q�$��
Врач: �����	#FF388E3C$
��Bold"�$��1��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1��$��3������ *
Врач+�� $& 5q�$��Тип: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��2��$��1������ *osmt+�� $& 5q�$��Кабинет: �����	#FF388E3C$
��Bold"�$��2��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��2��$��3������ *cab+�� $& 5q�$��
Цена: �����	#FF388E3C$
��Bold"�$��3��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3��$��1������ *pricer+�� $& 5q�$��Скидка: �����	#FF388E3C$
��Bold"�$��3��$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3��$��3������ *disc+�� $��4��#��[ $��4���� $ TalonButtonDelete��-S   $��5��$��4��#��[ 
�������$��Right=�$��0,0,55,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Отменить запись�� $ TalonGridWord��-T   $��5��$��2��#��[ 
�������$��Center=�$��0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Печать талона� -U   $ 
DoctorGrid��$y�Hidden=� �� $	��99* ��� $��4* �.+��� $ 
Horizontal=�$��0q�$��0��.+��� $��10,70,0,478q�$	��370��.+��� -V   $ DocotorFindTextBox��$ 
Поиск��$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $ 
Horizontal=�$��5,77,0,0q�$	��603��$	��Top=�.+��� -W   $ FindDoctorBut��#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� -X   $ 	AddDoctor��#��[ $	��155��$: 4Добавить нового врача в базу��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��15,0,0,0q�.��Добавить врача�� -Y   $ 	CheckSpec��#��[ $	��240��$: 4Добавить нового врача в базу��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��15,0,0,0q�.��/-Просмотр специальностей�� $��	0,130,0,0q�$��0��.+�  -Z   $ DoctorDataGrid��$��0 8 0 0q� . $ *  .  $ 8q� .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  ��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$ �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $& 5q�$!��Начало приема: �����	#FF388E3C$
��Bold"�$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1������ *	timeStart+�� $& 5q�$��Конец приема: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3������ *	timeEnd+�� $��1��#��[ $��4���� $ DeleteDoctor��-[   $��2��$��4��#��[ 
�������$��Center=�$- 'Удалить врача из базы��$��0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Удалить�� $ 
EditDoctor��-\   $��2��$��2��#��[ 
�������$��Center=�$C =Редактировать информацию о враче��$��0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Редактировать� -]   $ 	UsersGrid��$y�Hidden=� �� $
��100* ��� $��3* �.+��� $ 
Horizontal=�$��0q�$��0��.+��� $��10,70,0,478q�$	��370��.+��� -^   $ UserFindBox��$ 
Поиск��$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $ 
Horizontal=�$��5,77,0,0q�$	��452��$	��Top=�$��37��.+��� -_   $ UserFindBut��#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� -`   $ AddUser��#��[ $	��223��$: 4Добавить нового врача в базу��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��15,0,0,0q�.��+)Добавить пользователя�� $��	0,130,0,0q�$��0��.+�  -a   $ UserDataGrid��$��0 8 0 0q� . $ *  .  $ 8q� .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  ��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$ �� .R�]� 
�������.+�� $
��0,10q� �� $��* ��� $��* �% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $ 
DeleteUser��-b   $��2��$��1��#��[ 
�������$��Center=�$- 'Удалить врача из базы��$��0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Удалить�� $ EditUser��-c   $��2��$��0��#��[ 
�������$��Center=�$C =Редактировать информацию о враче��$��0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(����� $' id�.��Редактировать� -d   $ ClientAdminGrid��$y�Hidden=� �� $
��504* ��� $	��11* �.+��� $ 
Horizontal=�$��0q�$��0��.+��� $��10,70,0,478q�$	��370��.+��� -e   $ ClinentAdminFindTextBox��$ 
Поиск��$^ XВведите запрос и нажмите 'Найти' или клавишу 'Enter'��$��0,0,12,0q�$%��/Medkit;component/Fonts/#Roboto)�$��14(��� $ 
Horizontal=�$��
5,77,0,480q�$	��Top=�.+��� -f   $ FindAdminClientBut��#��[ $	��100��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��
Найти�� -g   $ 	AddClient��#��[ $	��223��$> 8Добавить нового клиента в базу��
�������$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��15,0,0,0q�.��!Добавить клиента�� $��	0,130,0,0q�$��0��.+�  -h   $ ClientAdminDataGrid��$��0 8 0 0q� . $ *  .  $ 8q� .  $%��/Medkit;component/Fonts/#Roboto)�$W QКликните по строке для подробной информации��$��14(�����  ��%�   '        7 �� 8    "!  .��� " � ��# �	#FF388E3C�� " � ��
# ������� " � ��$+# %/Medkit;component/Fonts/#Roboto Black)��� " � ��$# 16(�$ �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �% �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $& 5q�$!��Дата рождения: �����	#FF388E3C$
��Bold"�$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��1������ *dt+�� $& 5q�$��Телефон: �����	#FF388E3C$
��Bold"�$��2��$%��/Medkit;component/Fonts/#Roboto)��� $& 5q�$��3������ *	telephone+�� $��1��#��[ $��4���� $ 
Horizontal=�$��2��$��4��$��Center=�$��Center=�.+��� -i   #��[ $	��150��
�������$��Center=�$��0,0,5,0q����� $' id�.��Редактировать�� -j   #��[ $	��150��
�������$��Center=�$��5,0,0,0q����� $' id�.��Удалить�� -k   $ shadow��$y�Hidden=����	#BF000000���� *ActualWidth+$ Window������ *ActualHeight+$ Window��'  !MaterialDesignThemes.Wpf.Snackbar  -l   8  Name$8 	snackInfo��$��0,0,0,10q�9   MessageQueue9 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  