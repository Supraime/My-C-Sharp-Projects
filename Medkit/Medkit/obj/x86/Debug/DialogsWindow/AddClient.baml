   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   $    Medkit.DialogsWindow.AddClient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  	AddClient��5
   	   $	��500��6   $	��500��6(    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��44* �6   �� 5      $	��46* �6   �� 5      $	��46* �6   �� 5      $	��46* �6   �� 5      $	��47* �6   �� 5      $	��44* �6   �� 5      $
��135* �6   �� 5      $	��92* �6   .+�5   
   �� ���	#FF388E3C$��2��6%   6;   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�5!      $��32��5"      
�������$��32��5$      $��Center=�5%      �� 5&      -   5         ��Name$ 
NameDialog��5&      $+��%/Medkit;component/Fonts/#Roboto Black)�6(   $��16(�6[   $
��Left=�6i   $��Center=�6�   
�������$
��Bold"�6�   .��6�   Новый клиент6�   5'      �� 5(   
   -   5        	 ��Name$	 	FamClient��5)      
 �� 	MaxLength$	
 100��5*      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Фамилия клиента��5-         FloatingScale$
 0.90Q�5.       %  !MaterialDesignFloatingHintTextBox#��[  5/      $��1��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 50   
   -   5        $	 
NameClient��51      $	
 100��52      $ Имя клиента��55      $
 0.90Q�56      #��[  57      $��2��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 58   
   -   5        $	 SnameClient��59      $	
 100��5:      $% Отчество клиента��5=      $
 0.90Q�5>      #��[  5?      $��3��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   $	��Top=�6�   $��44��6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5@   
   -   5          Name$ PhoneBox��5D      $ Телефон��5A         Mask$ +79999999999��5B      $
 13��5C      $
 0.90Q�5E      #��[  5F      $��4��5G      $
��15,0q�6   $��0��6,   $%��/Medkit;component/Fonts/#Roboto)�6<   $��14(�6i   $��Bottom=�6w   $��44��6�   (  "System.Windows.Controls.DatePicker  5H   
   -   5          Name$ DateDay��5K      $ Дата рождения��5I       � Language$ ru-RU�5J      $��1��5L       ( $MaterialDesignFloatingHintDatePicker#��[ 5M      $
 0.90Q�5N      $��0,0,15,0q�6<   $��4��6N   $��Bottom=�6[   $%��/Medkit;component/Fonts/#Roboto)�6v   $��14(�6�   $��38��6�   �� 5O   
   -   5        $	 
SerialPass��5P      $
 4��5Q      $! Серия паспорта��5R      $
 0.90Q�5S      #��[  5T      $��5��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��0��6�   �� 5U   
   -	   5        $	 NumPass��5V      $
 6��5W      $! Номер паспорта��5X      $
 0.90Q�5Y      #��[  5Z      $��5��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $��0,0,15,0q�6�   $��1��6�   �� 5[   
   $��7��6   $��2��6"   $��Bottom=�66   $��84��6Q   .+�5\      �� -
   5         ��Name$ AcceptButton��5\   0    " MaterialDesignRaisedDarkButton#��[ 6G   $��
10,0,10,10q�6   $%��/Medkit;component/Fonts/#Roboto)�6�   $��16(�6�   
�������.��6�   Добавить6�   �� 5]       �� IsCancel . #��[ 6%   $��
10,0,10,10q�6]   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   
�������.��6�   Отмена6�   5^      �� 5_   
   -   5        $ 
WarningMsg��5_   $   $y�Hidden=�6   ���	#FFD42626$��6��6O   $��2��6\   $%��/Medkit;component/Fonts/#Roboto)�6p   $��16(�6�   $��5,0,0,0q�6�   $��Bottom=�6�   $��27��6�   .��6�   %#Заполните все поля!6�   5`      5a      