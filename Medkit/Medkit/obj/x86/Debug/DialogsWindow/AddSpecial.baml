   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   %    Medkit.DialogsWindow.AddSpecial   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
AddSpecial��5	   	   $��206.128��6   $	��500��6-    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $	��48* �6   �� 5      $	��37* �6   �� 5      $	��84* �6   .+�5   
   �� ���	#FF388E3C6'   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�5      $��32��5      
�������$��32��5      $��Center=�5      �� 5      -   5         ��Name$ NameBox��5      $+��%/Medkit;component/Fonts/#Roboto Black)�6%   $��16(�6X   $
��Left=�6f   $��Center=�6�   
�������$
��Bold"�6�   .��6�   '%Новая специальность6�   5      �� 5   
   -   5         ��Name$ SpecNameBox��5       )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$1	 +Название специальности��5!      
   FloatingScale$

 0.90Q�5#       %  !MaterialDesignFloatingHintTextBox#��[  5$      $��1��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $	��Top=�6�   �� 5%   
   -   5        $ 
WarningMsg��5%   $   $y�Hidden=�6   ���	#FFD42626$��2��6O   $%��/Medkit;component/Fonts/#Roboto)�6\   $��16(�6�   $��5,0,0,0q�6�   $��Bottom=�6�   $��27��6�   .��6�   !Введите название6�   �� 5&   
   $��3��6   $��Bottom=�6"   $��84��6=   .+�5'      �� -   5         ��Name$ AddSpec��5'       " MaterialDesignRaisedDarkButton#��[ 6&   $��
10,0,10,10q�6^   $%��/Medkit;component/Fonts/#Roboto)�6r   $��16(�6�   .��6�   Добавить6�   �� 5(       �� IsCancel . #��[ 6%   $��
10,0,10,10q�6]   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   .��6�   Отмена6�   5)      5*      5+      